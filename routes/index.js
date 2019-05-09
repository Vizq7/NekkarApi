const express = require("express")
const userController = require("../Controllers/user").userController
const router = express.Router();

router.get('/api/v1/CheckUserExists/:userName/:password', userController.CheckUserExists)
router.get('/api/v1/GetUserTasks/:id', userController.GetUserTasks)
router.get('/api/v1/GetAssemblyPdf/:id', userController.GetAssemblyPdf)

module.exports = {
    router
}