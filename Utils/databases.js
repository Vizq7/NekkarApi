const Sequelize = require("sequelize")

var SecureCore = new Sequelize("SecureCore", "nekkar", "S2am2018",{
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

var XWingsFactory = new Sequelize("XWingsFactory", "nekkar", "S2am2018",{
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

module.exports = {
    SecureCore,
    XWingsFactory
}