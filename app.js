const router = require("./routes/index")
const express = require("express")
const expressOasGenerator = require("express-oas-generator")
const bodyParser = require("body-parser")

const app = express()
expressOasGenerator.init(app, {})

app.use(bodyParser.urlencoded({ extended: false }));
app.use(router.router);

const PORT = 5000;

app.listen(process.env.PORT || PORT, () => {
  console.log(`server running on port ${PORT}`)
});