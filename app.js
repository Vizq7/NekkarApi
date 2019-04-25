const router = require("./routes/index")
const express = require("express")
const bodyParser = require("body-parser")

const app = express()

app.use(bodyParser.urlencoded({ extended: false }));
app.use(router.router);

const PORT = 5000;

const Sequelize = require("sequelize")
var sequelize = new Sequelize("XWingsFactory", "nekkar", "S2am2018",{
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

app.listen(process.env.PORT || 5000, () => {
  console.log(`server running on port ${PORT}`)
  
  sequelize
  .authenticate()
  .then(() => {
    console.log('Connection has been established successfully.');
  })
  .catch(err => {
    console.error('Unable to connect to the database:', err);
  });
});