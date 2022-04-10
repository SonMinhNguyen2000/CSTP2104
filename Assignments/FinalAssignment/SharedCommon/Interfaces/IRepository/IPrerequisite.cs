namespace Shared.Interfaces;

public interface IPrerequisite
{
    List<String> getPrerequisiteGroupId(string courseId);
    List<String> getPrerequisiteId(string groupPrerequisiteId);
}