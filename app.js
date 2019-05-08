const router = require("./routes/index")
const express = require("express")
const bodyParser = require("body-parser")

const app = express()

app.use(bodyParser.urlencoded({ extended: false }));
app.use(router.router);

const PORT = 5000;

app.listen(process.env.PORT || 5000, () => {
  console.log(`server running on port ${PORT}`)
  
  /*sequelize
  .authenticate()
  .then(() => {
    console.log('Connection has been established successfully.');
    sequelize
      .query("select * from ReferenceTypes").then(rows => {
        console.log(rows);
      })
  })
  .catch(err => {
    console.error('Unable to connect to the database:', err);
  });*/
});