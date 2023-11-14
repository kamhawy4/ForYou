using Microsoft.AspNetCore.Mvc;

namespace ForYou.Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class PostController : ControllerBase
    {
        private readonly CreateTaskCommandHandler _createTaskCommandHandler;
        private readonly CompleteTaskCommandHandler _completeTaskCommandHandler;
        private readonly GetTaskQueryHandler _getTaskQueryHandler;

        public PostController(
            CreateTaskCommandHandler createTaskCommandHandler,
            CompleteTaskCommandHandler completeTaskCommandHandler,
            GetTaskQueryHandler getTaskQueryHandler)
        {
            _createTaskCommandHandler = createTaskCommandHandler;
            _completeTaskCommandHandler = completeTaskCommandHandler;
            _getTaskQueryHandler = getTaskQueryHandler;
        }

        [HttpPost("create")]
        public IActionResult CreateTask([FromBody] CreateTaskCommand command)
        {
            _createTaskCommandHandler.Handle(command);
            return Ok();
        }

        [HttpPost("complete")]
        public IActionResult CompleteTask([FromBody] CompleteTaskCommand command)
        {
            _completeTaskCommandHandler.Handle(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var query = new GetTaskQuery { Id = id };
            var task = _getTaskQueryHandler.Handle(query);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }
    }
}
