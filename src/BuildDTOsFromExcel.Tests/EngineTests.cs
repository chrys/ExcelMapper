using BuildDTOsFromExcel.FileService;

using ExcelMapper;
using ExcelMapper.Configuration;

using Microsoft.Practices.ServiceLocation;

using NUnit.Framework;

namespace BuildDTOsFromExcel.Tests
{
    public class EngineTests
    {
        [TestFixture]
        public class When_given_a_list_of_excel_files
        {
            private IEngine _engine;

            [SetUp]
            public void SetUp()
            {
                ExcelMapperServiceLocator.SetUp();
                _engine = new Engine(new FileParser(new FileSystemService()), ServiceLocator.Current.GetInstance<IExcelToDTOMapper>());
            }

            [Test]
            public void Should_create_class_files_for_each_tab_and_write_a_success_message_if_excelmapper_run_is_success()
            {
                string[] args = new[] { "TestDirectory\\Users.xlsx" };

                Assert.AreEqual(DefaultSettings.SuccessMessage, _engine.Run(args));
            }

            [Test]
            public void Should_write_an_error_message_if_the_excelmapper_fails()
            {
                string[] args = new[] { "TestDirectory\\User.xlsx" };

                Assert.AreEqual(DefaultSettings.ErrorMessage, _engine.Run(args));
            }
        }
    }
}