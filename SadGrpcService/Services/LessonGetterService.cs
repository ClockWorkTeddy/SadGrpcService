using Grpc.Core;
using SadGrpcService.DataBase;
using SadGrpcService.Models.SqlServer;

namespace SadGrpcService.Services
{
    public class LessonGetterService(
        SadSchoolContext dbContext) : LessonsGetter.LessonsGetterBase
    {
        public override Task<LessonResponse> GetLesson(LessonRequest request, ServerCallContext context)
        {
            var lesson = new SadGrpcService.Models.SqlServer.Lesson();

            try
            {
                lesson = dbContext.Lessons.Find(request.Id);
            }
            catch (Exception ex)
            {
                lesson.Date = "Some problems with database";
            }

            var resultLesson = new Lesson { Date = lesson.Date, SheduledLessonId = lesson.ScheduledLessonId.Value };
            var result = new LessonResponse { Lesson = resultLesson };

            return Task.FromResult(result);
        }
    }
}
