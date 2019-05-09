const sequelizeSecureCore = require("../Utils/databases").SecureCore
const sequelizeFactory = require("../Utils/databases").XWingsFactory
  
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
            sequelizeFactory.query("select r.descReference, r.Photo, r.ItemDescription, r.idReference " +
            "from DailyUserTasks d, [References] r "+
            "where d.idUser = " + req.params.id + " " +
            "and r.idReference = d.idreference").then(rows => {
              if(rows[0].length > 0){
                return res.status(200).send({
                  message: rows[0]
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

    GetAssemblyPdf(req, res){
      if(req.params.id){
        sequelizeFactory
          .authenticate()
          .then(() => {
            sequelizeFactory.query("select Instructions " +
            "from AssemblyInstructions " +
            "where idreference = " + req.params.id).then(rows =>{
              if(rows[0].length > 0){
                var data = {
                  pdf: rows[0][0].Instructions
                }

                return res.status(200).send({
                  message: data
                })
              }else{
                return res.status(300).send({
                  message: 'invalid id'
                })
              }
            })
          })
      }else{
        return res.status(400).send({
          message: 'empty assembly id'
        })
      }
    }
}

const userController = new UserController()

module.exports = {
    userController
}