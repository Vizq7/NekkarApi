const Sequelize = require("sequelize")
var sequelize = new Sequelize("SecureCore", "nekkar", "S2am2018",{
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
          sequelize
          .authenticate()
          .then(() => {
            sequelize
              .query("select * from Users where lower(UserName) = '" + req.params.userName
                    + "' and Password = '" + req.params.password + "'").then(rows => {
                  if(rows[0].length > 0){
                    const idUser = rows[0][0].idUser
                    sequelize.query("select Avatar from UserAvatars where idUser = " + idUser).then(rowsAvatar => {
                      var data = {
                        IdUser: idUser,
                        UserAvatar: rowsAvatar[0][0].Avatar
                      }
                      return res.status(200).send({
                        success: 'true',
                        message: data
                      })
                    })
                  }else{
                      return res.status(300).send({
                        success: 'false',
                        message: 'invalid user'
                      })
                  }
              })
          })
          .catch(err => {
            return res.status(500).send({
              success: 'false',
              message: 'database error: ' + err
            })
          });
        }else{
          return res.status(400).send({
            success: 'false',
            message: 'empy userName/password',
          });
        }
    }
}

const userController = new UserController()

module.exports = {
    userController
}