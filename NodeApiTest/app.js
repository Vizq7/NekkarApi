const router = require("./routes/index")
const express = require("express")
const bodyParser = require("body-parser")

const app = express()

app.use(bodyParser.urlencoded({ extended: false }));
app.use(router.router);

const PORT = 5000;

app.listen(PORT, () => {
  //console.log(`server running on port ${PORT}`)
});