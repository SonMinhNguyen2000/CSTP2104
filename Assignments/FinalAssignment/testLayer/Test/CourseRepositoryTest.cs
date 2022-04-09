using Shared.Entities;
using testLayer.Mock;

namespace testLayer.Test;

public static class CourseRepositoryTest
{
    public static void getPrerequisite(MockCourseRepository mockRepo)
    {
        List<List<Course>>? prerequisiteGroups = mockRepo.getPrerequisite("cstp1206");
        if (prerequisiteGroups != null)
        {
            foreach (var prerequisiteGroup in prerequisiteGroups)
            {
                foreach (var prerequisite in prerequisiteGroup)
                {
                    Console.WriteLine(prerequisite.ToString());
                }
            }
        }
        else
        {
            Console.WriteLine("null");
        }
    }
}