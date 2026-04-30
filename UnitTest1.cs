namespace WebAPI.UnitTests
{
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Xunit;
    using FluentAssertions;
    using WebAPI.Models;
    using WebAPI.Controllers;
    using WebAPI.Data_Layer_Service;




    public class EmployeeControllerTests
    {
        [Fact]
        public void Get_ShouldReturnEmployeeList()
        {
            /*// Arrange
            var mockService = new Mock<IEmployeeService>();
            var employeeTable = new DataTable();
            employeeTable.Columns.Add("EmployeeID", typeof(long));
            employeeTable.Columns.Add("EmployeeName", typeof(string));
            employeeTable.Columns.Add("Department", typeof(string));
            employeeTable.Columns.Add("MailID", typeof(string));
            employeeTable.Columns.Add("DOJ", typeof(string));

            // Add a dummy row to the DataTable
            employeeTable.Rows.Add(1, "Sphelele Mendu", "Digital Transformation", "sphelelem@dt.com", "2023-01-01");

            mockService.Setup(service => service.GetEmployees()).Returns(employeeTable);

            var controller = new EmployeesController(mockService.Object);

            // Act
            var result = controller.Get() as HttpResponseMessage;
            var responseContent = result.Content.ReadAsAsync<DataTable>().Result;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            responseContent.Rows.Count.Should().Be(1);
            responseContent.Rows[0]["EmployeeName"].Should().Be("Sphelele Mendu");
            responseContent.Rows[0]["Department"].Should().Be("Digital Transformation");
            responseContent.Rows[0]["MailID"].Should().Be("sphelelem@dt.com");*/
        }
    }

}