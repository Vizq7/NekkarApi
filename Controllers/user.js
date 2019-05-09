const Sequelize = require("sequelize")
var sequelizeSecureCore = new Sequelize("SecureCore", "nekkar", "S2am2018",{
    host: "nekkar.database.windows.net",
    dialect: "mssql",
    pool: {
      max: 5,
      min: 0,
      idle: 10000
    },
    dialectOptions: {
      options: {
        encrypt: true
      }
    }
  })

  var sequelizeFactory = new Sequelize("XWingsFactory", "nekkar", "S2am2018",{
    host: "nekkar.database.windows.net",
    dialect: "mssql",
    pool: {
      max: 5,
      min: 0,
      idle: 10000
    },
    dialectOptions: {
      options: {
        encrypt: true
      }
    }
  })
  
class UserController{
    
    CheckUserExists(req, res){
        if (req.params.userName && req.params.password) {
          sequelizeSecureCore
          .authenticate()
          .then(() => {
            sequelizeSecureCore
              .query("select * from Users where lower(UserName) = '" + req.params.userName
                    + "' and Password = '" + req.params.password + "'").then(rows => {
                  if(rows[0].length > 0){
                    const idUser = rows[0][0].idUser
                    sequelizeSecureCore.query("select Avatar from UserAvatars where idUser = " + idUser).then(rowsAvatar => {
                      var data = {
                        IdUser: idUser,
                        UserAvatar: rowsAvatar[0][0].Avatar
                      }
                      return res.status(200).send({
                        message: data
                      })
                    })
                  }else{
                      return res.status(400).send({
                        message: 'invalid user'
                      })
                  }
              })
          })
          .catch(err => {
            return res.status(500).send({
              message: 'database error: ' + err
            })
          });
        }else{
          return res.status(400).send({
            message: 'empty userName/password',
          });
        }
    }

    GetUserTasks(req, res){
      if(req.params.id){
        sequelizeFactory
          .authenticate()
          .then(() => {
            sequelizeFactory.query("select r.descReference, r.Photo, r.ItemDescription " +
            "from DailyUserTasks d, [References] r "+
            "where d.idUser = " + req.params.id + " " +
            "and r.idReference = d.idreference").then(rows => {
              if(rows[0].length > 0){
                var data = {
                  partName: rows[0][0].descReference,
                  partPhoto: rows[0][0].Photo,
                  partDesc: rows[0][0].ItemDescription
                }

                return res.status(200).send({
                  message: data
                })
              }else{
                return res.status(400).send({
                  message: 'invalid user'
                })
              }
            })
          })
      }else{
        return res.status(400).send({
          message: 'empty id user'
        })
      }
    }
}

const userController = new UserController()

module.exports = {
    userController
}