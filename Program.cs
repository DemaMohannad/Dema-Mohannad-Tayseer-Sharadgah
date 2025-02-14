using System.ComponentModel;
using System.Linq;
using first_project.DTO;
using first_project.Entities;

namespace first_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var dbContext = new EFCoreDbContext();
            //AddDepartment(dbContext);
            //AddPosition(dbContext);
            //AddEmployee(dbContext);
            //UpdateEmployee(dbContext, "emp1", "Dema", 13, 15, 200.00m);
            //UpdateVacationsDays(dbContext, "emp1", 1);
            
            SubmitNewVacationRequest(dbContext, "emp1","S", "Description1", new DateTime(2025, 4, 4), new DateTime(2025, 4, 10));

            var employeesQry = (from employee in dbContext.Employees
                                join Department in dbContext.Departments on employee.DepID equals Department.DepartmentID
                                select new
                                {
                                    EmployeeNumber = employee.EmployeeNumber,
                                    EmployeeName = employee.EmployeeName,
                                    DepartmentID = Department.DepartmentID,
                                    Salary = employee.Salary,

                                }).ToList();
            // foreach(var employee in employeesQry)
            // {
            // Console.WriteLine($"EmployeeNumber:{employee.EmployeeNumber},EmployeeName:{employee.EmployeeName},DepartmentID:{employee.DepartmentID},Salary:{employee.Salary}");
            // }


        }
        private static void AddDepartment(EFCoreDbContext dbContext)
        {
            var Dept1 = new Department("Human Resources");
            var Dept2 = new Department("Finance");
            var Dept3 = new Department("Marketing");
            var Dept4 = new Department("Sales");
            var Dept5 = new Department("IT Support");
            var Dept6 = new Department("Research and Development");
            var Dept7 = new Department("Customer Service");
            var Dept8 = new Department("Operations");
            var Dept9 = new Department("Legal");
            var Dept10 = new Department("Administration");
            var Dept11 = new Department("Quality Assurance");
            var Dept12 = new Department("Procurement");
            var Dept13 = new Department("Training and Development");
            var Dept14 = new Department("Public Relations");
            var Dept15 = new Department("Product Management");
            var Dept16 = new Department("Supply Chain");
            var Dept17 = new Department("Business Development");
            var Dept18 = new Department("Data Analysis");
            var Dept19 = new Department("Graphic Design");
            var Dept20 = new Department("Facilities Management");

            dbContext.Departments.Add(Dept1);
            dbContext.Departments.Add(Dept2);
            dbContext.Departments.Add(Dept3);
            dbContext.Departments.Add(Dept4);
            dbContext.Departments.Add(Dept5);
            dbContext.Departments.Add(Dept6);
            dbContext.Departments.Add(Dept7);
            dbContext.Departments.Add(Dept8);
            dbContext.Departments.Add(Dept9);
            dbContext.Departments.Add(Dept10);
            dbContext.Departments.Add(Dept11);
            dbContext.Departments.Add(Dept12);
            dbContext.Departments.Add(Dept13);
            dbContext.Departments.Add(Dept14);
            dbContext.Departments.Add(Dept15);
            dbContext.Departments.Add(Dept16);
            dbContext.Departments.Add(Dept17);
            dbContext.Departments.Add(Dept18);
            dbContext.Departments.Add(Dept19);
            dbContext.Departments.Add(Dept20);

            dbContext.SaveChanges();
        }
        private static void AddPosition(EFCoreDbContext dbContext)
        {
            var Pos1 = new Position("CEO");
            var Pos2 = new Position("CFO");
            var Pos3 = new Position("CMO");
            var Pos4 = new Position("COO");
            var Pos5 = new Position("CTO");
            var Pos6 = new Position("HR Manager");
            var Pos7 = new Position("Sales Manager");
            var Pos8 = new Position("Marketing Specialist");
            var Pos9 = new Position("IT Specialist");
            var Pos10 = new Position("Accountant");
            var Pos11 = new Position("Project Manager");
            var Pos12 = new Position("Customer Service");
            var Pos13 = new Position("Graphic Designer");
            var Pos14 = new Position("Data Analyst");
            var Pos15 = new Position("Software Developer");
            var Pos16 = new Position("Operations Manager");
            var Pos17 = new Position("Legal Counsel");
            var Pos18 = new Position("Procurement Officer");
            var Pos19 = new Position("Quality Assurance Analyst");
            var Pos20 = new Position("Administrative Assistant");

            dbContext.Add<Position>(Pos1);
            dbContext.Add<Position>(Pos2);
            dbContext.Add<Position>(Pos3);
            dbContext.Add<Position>(Pos4);
            dbContext.Add<Position>(Pos5);
            dbContext.Add<Position>(Pos6);
            dbContext.Add<Position>(Pos7);
            dbContext.Add<Position>(Pos8);
            dbContext.Add<Position>(Pos9);
            dbContext.Add<Position>(Pos10);
            dbContext.Add<Position>(Pos11);
            dbContext.Add<Position>(Pos12);
            dbContext.Add<Position>(Pos13);
            dbContext.Add<Position>(Pos14);
            dbContext.Add<Position>(Pos15);
            dbContext.Add<Position>(Pos16);
            dbContext.Add<Position>(Pos17);
            dbContext.Add<Position>(Pos18);
            dbContext.Add<Position>(Pos19);
            dbContext.Add<Position>(Pos20);

            dbContext.SaveChanges();
        }
        private static void AddEmployee(EFCoreDbContext dbContext)
        {
            var employee1 = new Employee("emp1", "Employee1", 1, 6, "F", "", 100.00m);
            var employee2 = new Employee("emp2", "Employee2", 13, 15, "F", "", 100.00m);
            var employee3 = new Employee("emp3", "Employee3", 11, 19, "M", "", 100.00m);
            var employee4 = new Employee("emp4", "Employee4", 4, 7, "M", "", 100.00m);
            var employee5 = new Employee("emp5", "Employee5", 19, 13, "F", "", 100.00m);
            var employee6 = new Employee("emp6", "Employee6", 7, 12, "F", "", 100.00m);
            var employee7 = new Employee("emp7", "Employee7", 5, 9, "M", "", 100.00m);
            var employee8 = new Employee("emp8", "Employee8", 1, 6, "M", "", 100.00m);
            var employee9 = new Employee("emp9", "Employee9", 11, 19, "F", "", 100.00m);
            var employeeA = new Employee("emp10", "Employee10", 13, 15, "F", "", 100.00m);

            dbContext.Employees.Add(employee1);
            dbContext.Employees.Add(employee2);
            dbContext.Employees.Add(employee3);
            dbContext.Employees.Add(employee4);
            dbContext.Employees.Add(employee5);
            dbContext.Employees.Add(employee6);
            dbContext.Employees.Add(employee7);
            dbContext.Employees.Add(employee8);
            dbContext.Employees.Add(employee9);
            dbContext.Employees.Add(employeeA);

            dbContext.SaveChanges();
        }
        private static void UpdateEmployee(EFCoreDbContext dbContext, string employeeNumber, string Name, int depID, int posID, decimal salary)
        {
            var employee = dbContext.Employees.FirstOrDefault(e => e.EmployeeNumber == employeeNumber);
            if (employee != null)
            {
                employee.EmployeeName = Name;
                employee.DepID = depID;
                employee.PosID = posID;
                employee.Salary = salary;

                dbContext.SaveChanges();
                Console.WriteLine($"Employee Updated Successfully");
            }
            else
            {
                Console.WriteLine($"Employee Not Found");
            }
        }
        private static void UpdateVacationsDays(EFCoreDbContext dbContext, string employeeNumber, int vacdaystaken)
        {
            var employee = dbContext.Employees.FirstOrDefault(e => e.EmployeeNumber == employeeNumber);
            if (employee != null)
            {
                if (employee.Vacdaysleft >= vacdaystaken)
                {
                    employee.Vacdaysleft -= vacdaystaken;
                    dbContext.SaveChanges();
                    Console.WriteLine($"Vacation days left Updated Successfully");
                }
                else
                {
                    Console.WriteLine($"You have no vacation days left ");
                }
            }
            else
            {
                Console.WriteLine($"Employee Not Found");
            }
        }
        private static void SubmitNewVacationRequest(EFCoreDbContext dbContext, string employeeNumber, string vacTypeCode, string description, DateTime startdate, DateTime enddate)
        {
            bool overlap = dbContext.VacationRequests
                       .Where(e => e.EmpNumber == employeeNumber && e.RequestStateID != 3)
                       .Any(e => (startdate <= e.EndDate && enddate >= e.StartDate));

            if (overlap)
            {
                Console.WriteLine("Vacation Request Overlaps With Existing Requests");
                return;
            }
            var Request = new VacationRequest
            {
                ReqSubmissionDate = DateTime.Now,
                Description = description,
                EmpNumber = employeeNumber,
                VacTypeCode = vacTypeCode,
                StartDate = startdate,
                EndDate = enddate,
                TotalVacDaye = (enddate - startdate).Days + 1,
                RequestStateID = 1,
                ApprovedbyEmpNum = null,
                DeclinedbyEmpNum = null
            };
            dbContext.VacationRequests.Add(Request);
            dbContext.SaveChanges();
            Console.WriteLine("Vacation Request Submitted Successfully");
        }
        private static List<VacationRequest> ShowPendingVacationRequest(EFCoreDbContext dbContext)
        {
            var result = dbContext.VacationRequests.Where(v => v.RequestStateID == 1).ToList();
            return result;
        }
        private static void Approve(EFCoreDbContext dbContext, int requestID, string ApprovedbyEmpNum)
        {
            var Request = dbContext.VacationRequests.FirstOrDefault(e => e.RequestID == requestID);
            if (Request != null && Request.RequestStateID == 1)
            {
                Request.RequestStateID = 2;
                Request.ApprovedbyEmpNum = ApprovedbyEmpNum;
                var employee = Request.Employee;
                employee.Vacdaysleft -= Request.TotalVacDaye;
                if (employee.Vacdaysleft < 0)
                {
                    employee.Vacdaysleft = 0;
                }
                dbContext.SaveChanges();
                Console.WriteLine("Vacation Request Approved");
            }
            else
            {
                Console.WriteLine("Request not found OR Still in Process");
            }
        }
        private static void Decline(EFCoreDbContext dbContext, int requestID, string DeclinedbyEmpNum)
        {
            var Request = dbContext.VacationRequests.FirstOrDefault(e => e.RequestID == requestID);
            if (Request != null && Request.RequestStateID == 1)
            {
                Request.RequestStateID = 3;
                Request.DeclinedbyEmpNum = DeclinedbyEmpNum;
                dbContext.SaveChanges();
                Console.WriteLine("Vacation Request Declined");
            }
            else
            {
                Console.WriteLine("Request not found OR Still in Process");
            }
        }

        private static List<GetEmployeeByNumbercs> GetEmployeeByNumber(EFCoreDbContext dbContext , string employeeNumber)
        {
            var emp = (from employee in dbContext.Employees
                       where employee.EmployeeNumber == employeeNumber
                       join Department in dbContext.Departments on employee.DepID equals Department.DepartmentID
                       join Position in dbContext.Positions on employee.PosID equals Position.PositionID
                       select new GetEmployeeByNumbercs
                       {
                           EmployeeNumber = employee.EmployeeNumber,
                           EmployeeName = employee.EmployeeName,
                           DepartmentName = Department.DepartmentName,
                           PositionName = Position.PositionName,
                           Reportedtoempnum = employee.Reportedtoempnum,
                           Vacdaysleft = employee.Vacdaysleft,

                       }).ToList();
                      
            return emp;
        }
        private static List<Employee> GetEmployeeWithPendingRequest(EFCoreDbContext dbContext)
        {
            var employeesQry = (from employee in dbContext.Employees
                                join VacationRequest in dbContext.VacationRequests on employee.EmployeeNumber equals VacationRequest.EmpNumber
                                where VacationRequest.RequestStateID==1
                                select employee
                                ).ToList();
            return employeesQry;
        }
        private static List<VacationRequest> GetAllApprovedRequest(EFCoreDbContext dbContext, string employeeNumber)
        {
            var Request = (from VacationRequest in dbContext.VacationRequests
                           where VacationRequest.EmpNumber == employeeNumber && VacationRequest.RequestStateID == 2
                           select new VacationRequest
                           {
                               VacationType = VacationRequest.VacationType,
                               Description = VacationRequest.Description,
                               TotalVacDaye = VacationRequest.TotalVacDaye,
                               ApprovedbyEmpNum = VacationRequest.ApprovedbyEmpNum
                           }).ToList();

            return Request;
        }

        private static List<ShowAllPendingRequest> ShowAllPendingRequest(EFCoreDbContext dbContext, string employeeNumber)
        {
            var Request = (from VacationRequest in dbContext.VacationRequests
                           join employee in dbContext.Employees on VacationRequest.EmpNumber equals employee.EmployeeNumber
                           where VacationRequest.EmpNumber == employeeNumber && VacationRequest.RequestStateID == 1
                           select new ShowAllPendingRequest
                           {
                               Description = VacationRequest.Description,
                               EmpNumber = VacationRequest.EmpNumber,
                               EmpName= employee.EmployeeName,
                               ReqSubmissionDate = VacationRequest.ReqSubmissionDate,
                               TotalVacDaye = VacationRequest.TotalVacDaye,
                               StartDate = VacationRequest.StartDate,
                               EndDate = VacationRequest.EndDate,
                               Salary = employee.Salary

                           }).ToList();

            return Request;
        }


    }
}
