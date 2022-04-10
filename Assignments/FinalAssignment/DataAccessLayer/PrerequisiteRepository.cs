using Shared.Interfaces;

namespace DataAccessLayer;

public class PrerequisiteRepository:IPrerequisite
{
    public IDataService DataService { get; set; }

    public PrerequisiteRepository(IDataService dataSource)
    {
        DataService = dataSource;
    }

    //get group prerequisite ids of a specific course
    public List<String> getPrerequisiteGroupId(string CourseId)
    {
        List<String> prerequisitesGroupId = new List<String>();
        DataService.Query("Select PrerequisiteGroupId from prerequisite where CourseId = @id");
        DataService.Bind("@id", CourseId);
        var reader = DataService.Execute();
        while (reader.Read())
        {
            prerequisitesGroupId.Add(reader["PrerequisiteGroupId"].ToString());
        }
        DataService.ClearQuery();
        reader.Close();
        return prerequisitesGroupId;
    }
    
    //get all prerequisite ids of 1 prerequisite group
    public List<String> getPrerequisiteId(string groupPrerequisiteId)
    {
        List<String> prerequisitesId = new List<string>();
        DataService.Query("select CourseId from prerequisiteGroupCourse where GroupId = @gid");
        DataService.Bind("@gid", groupPrerequisiteId);
        var reader = DataService.Execute();
        while (reader.Read())
        {
            prerequisitesId.Add(reader["CourseId"].ToString());
        }
        DataService.ClearQuery();
        reader.Close();
        return prerequisitesId;
    }
}