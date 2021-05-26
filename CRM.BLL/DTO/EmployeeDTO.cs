using System;

namespace CRM.BLL.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
