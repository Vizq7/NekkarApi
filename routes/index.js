const express = require("express")
const TodoController = require("../Controllers/todos").todoController
const router = express.Router();

router.get('/api/v1/GetTodo', TodoController.getAllTodos);
router.get('/api/v1/GetTodo/:id', TodoController.getTodo);
router.post('/api/v1/CreateTodo', TodoController.createTodo);
router.put('/api/v1/UpdateTodo/:id', TodoController.updateTodo);
router.delete('/api/v1/DeleteTodo/:id', TodoController.deleteTodo);

module.exports = {
    router
}