const express = require("express")
const userController = require("../Controllers/user").userController
const router = express.Router();

/*router.get('/api/v1/GetTodo', TodoController.getAllTodos);
router.get('/api/v1/GetTodo/:id', TodoController.getTodo);
router.post('/api/v1/CreateTodo', TodoController.createTodo);
router.put('/api/v1/UpdateTodo/:id', TodoController.updateTodo);
router.delete('/api/v1/DeleteTodo/:id', TodoController.deleteTodo);*/

router.get('/api/v1/CheckUserExists/:userName/:password', userController.CheckUserExists)
router.get('/api/v1/GetUserTasks/:id', userController.GetUserTasks)
router.get('/api/v1/GetAssemblyPdf/:id', userController.GetAssemblyPdf)

module.exports = {
    router
}