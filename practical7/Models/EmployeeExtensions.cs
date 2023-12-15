namespace practical7.Extensions
{
    public static class EmployeeExtensions
    {
        public static string GetEmployeeInfo(this Employee employee)
        {
            if (employee == null)
            {
                return "Employee information not available.";
            }

            string hiredDateInfo = employee.HiredDate.HasValue
                ? employee.HiredDate.Value.ToString("MM/dd/yyyy")
                : "Not specified";

            return $"Employee ID: {employee.Id}, Name: {employee.Name}, Hired Date: {hiredDateInfo}";
        }
    }
}