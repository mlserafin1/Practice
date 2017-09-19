using CarDealership.Data.ADO;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.IntegrationTests.ADO
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Init()
        {
            using(var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadMakes()
        {
            var repo = new MakesRepositoryADO();

            var makes = repo.GetAll().ToList();

            Assert.AreEqual(3, makes.Count());
            Assert.AreEqual("Ford", makes[0].MakeName);
            Assert.AreEqual(1, makes[0].MakeId);
            Assert.AreEqual("admin@admin.com", makes[1].UserId);
        }

        [Test]
        public void CanLoadModels()
        {
            var repo = new ModelsRepositoryADO();

            var models = repo.GetAll().ToList();

            Assert.AreEqual(6, models.Count());
            Assert.AreEqual("Forester", models[2].ModelName);
            Assert.AreEqual(2, models[3].MakeId);
            Assert.AreEqual(5, models[4].ModelId);
            Assert.AreEqual("admin@admin.com", models[1].UserId);
        }

        [Test]
        public void CanLoadCustomers()
        {
            var repo = new CustomerInfoRepositoryADO();

            var customers = repo.GetAll();

            Assert.AreEqual(3, customers.Count());
        }

        [Test]
        public void CanLoadVehicles()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicles = repo.GetAll().ToList();

            Assert.AreEqual(7, vehicles.Count());
            Assert.AreEqual("SUV", vehicles[0].BodyStyle);
            Assert.AreEqual("Gray", vehicles[1].Interior);
            Assert.AreEqual("Tucson", vehicles[2].Model);
            Assert.AreEqual("Manual", vehicles[5].Transmission);
        }

        [Test]
        public void CanLoadContactInquiries()
        {
            var repo = new ContactInquiriesRepositoryADO();

            var inquiries = repo.GetAll().ToList();

            Assert.AreEqual(1, inquiries.Count());
            Assert.AreEqual("John McEnroe", inquiries[0].Name);
        }

        [Test]
        public void CanAddContactInquiry()
        {
            var repo = new ContactInquiriesRepositoryADO();

            ContactInquiry contact = new ContactInquiry();
            contact.Name = "Little Bobby Tables";
            contact.Phone = "222-222-2222";
            contact.Email = "bobbydroptables@aol.com";
            contact.Message = "Please call me about the Lambo.";

            repo.AddInquiry(contact);
            var inquiries = repo.GetAll().ToList();

            Assert.AreEqual(2, inquiries.Count());
            Assert.AreEqual(2, inquiries[1].ContactInfoId);
            Assert.AreEqual("Little Bobby Tables", inquiries[1].Name);
        }

        [Test]
        public void CanLoadPurchases()
        {
            var repo = new PurchasesRepositoryADO();

            var purchases = repo.GetAll().ToList();

            Assert.AreEqual(3, purchases.Count);
            Assert.AreEqual("ac3ece39-adf7-4823-bfc3-3ce5a42e8d0b", purchases[0].UserId);
            Assert.AreEqual("VIN Test", purchases[0].Message);
        }

        [Test]
        public void CanLoadPurchaseTypes()
        {
            var repo = new PurchaseTypesRepositoryADO();

            var purchaseTypes = repo.GetAll().ToList();

            Assert.AreEqual(3, purchaseTypes.Count());
            Assert.AreEqual("Cash", purchaseTypes[1].PurchaseTypeName);
        }

        [TestCase(1)]
        public void CanGetVehicleById(int id)
        {
            var repo = new VehiclesRepositoryADO();

            var vehicle = repo.GetById(id);

            Assert.IsTrue(vehicle != null);
            Assert.AreEqual("Subaru", vehicle.Make);
        }

        [Test]
        public void CanCreateVehicle()
        {
            var repo = new VehiclesRepositoryADO();

            Vehicle vehicle = new Vehicle();
            vehicle.Price = 25000.00M;
            vehicle.Vin = "AWJ588976HYFJ";
            vehicle.ModelId = 2;
            vehicle.Year = "2014";
            vehicle.IsNew = false;
            vehicle.Msrp = 28000.00M;
            vehicle.Color = "Green";
            vehicle.Interior = "Black";
            vehicle.Transmission = "Automatic";
            vehicle.Mileage = "89275";
            vehicle.Description = "Scratch and dent, still good";
            vehicle.BodyStyle = "Car";
            vehicle.PictureFileName = "placeholder.png";
            vehicle.IsFeatured = true;

            var test = repo.GetAll();
            Assert.AreEqual(7, test.Count());

            repo.CreateVehicle(vehicle);
            Assert.AreEqual(8, vehicle.VehicleId);

            var car = repo.GetById(8);
            Assert.AreEqual(car.Color, "Green");
            Assert.AreEqual(false, car.IsNew);

            var test2 = repo.GetAll();
            Assert.AreEqual(8, test2.Count());
        }

        [Test]
        public void CanUpdateVehicle()
        {
            var repo = new VehiclesRepositoryADO();

            Vehicle vehicle = new Vehicle();
            vehicle.VehicleId = 2;
            vehicle.Price = 25000.00M;
            vehicle.Vin = "AWJ588976HYFJ";
            vehicle.ModelId = 2;
            vehicle.Year = "2014";
            vehicle.IsNew = false;
            vehicle.Msrp = 28000.00M;
            vehicle.Color = "Green";
            vehicle.Interior = "Black";
            vehicle.Transmission = "Automatic";
            vehicle.Mileage = "89,275";
            vehicle.Description = "Scratch and dent, still good";
            vehicle.BodyStyle = "Car";
            vehicle.PictureFileName = "placeholder.png";
            vehicle.IsFeatured = true;

            repo.UpdateVehicle(vehicle);

            var test = repo.GetById(2);
            Assert.AreEqual(vehicle.Year, "2014");
            Assert.AreEqual(vehicle.Mileage, "89,275");

            var test2 = repo.GetAll();
            Assert.AreEqual(7, test2.Count());
        }

        [Test]
        public void CanDeleteVehicle()
        {
            var repo = new VehiclesRepositoryADO();

            repo.DeleteVehicle(2);

            var test = repo.GetAll();
            Assert.AreEqual(test.Count(), 6);

            var test2 = repo.GetById(1);
            Assert.AreEqual(test2.Color, "Blue");
        }

        [Test]
        public void CanAddMake()
        {
            var repo = new MakesRepositoryADO();

            Make make = new Make();
            make.MakeName = "Chevrolet";

            repo.CreateMake(make);
            var test = repo.GetAll().ToList();

            Assert.AreEqual(4, test.Count());
            Assert.AreEqual("Chevrolet", test[0].MakeName);
            Assert.AreEqual(2, test[3].MakeId);
        }

        [Test]
        public void CanAddModel()
        {
            var repo = new ModelsRepositoryADO();

            Model model = new Model();
            model.MakeId = 1;
            model.ModelName = "Ranger";

            repo.CreateModel(model);
            var test = repo.GetAll().ToList();

            Assert.AreEqual(7, test.Count());
            Assert.AreEqual(1, test[6].MakeId);
            Assert.AreEqual("Ranger", test[6].ModelName);
            Assert.AreEqual("Forester", test[2].ModelName);
            Assert.AreEqual(2, test[2].MakeId);
        }

        [Test]
        public void CanGetFeaturedVehicles()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicles = repo.GetFeatured().ToList();

            Assert.AreEqual(6, vehicles.Count);
            Assert.AreEqual(true, vehicles[1].IsFeatured);
        }

        [Test]
        public void CanSearchNewVehicles()
        {
            var repo = new VehiclesRepositoryADO();

            var parameters = new VehicleSearchParameters();

            parameters.TextBoxTerm = "Fo";

            var vehicles = repo.SearchNewAvailableVehicles(parameters);
            Assert.AreEqual(3, vehicles.Count());

            var parameters2 = new VehicleSearchParameters();

            parameters2.MinPrice = 20000.00M;
            parameters2.MaxPrice = 35000.00M;

            var vehicles2 = repo.SearchNewAvailableVehicles(parameters2);
            Assert.AreEqual(2, vehicles2.Count());

            /*var parameters3 = new VehicleSearchParameters();

            parameters3.MinYear = "2016";
            parameters3.MaxYear = "2017";

            var vehicles3 = repo.SearchNewAvailableVehicles(parameters3);
            Assert.AreEqual(4, vehicles3.Count());*/

            var parameters4 = new VehicleSearchParameters();

            var vehicles4 = repo.SearchNewAvailableVehicles(parameters4);
            Assert.AreEqual(3, vehicles4.Count());
        }

        [Test]
        public void CanSearchUsedVehicles()
        {
            var repo = new VehiclesRepositoryADO();

            var parameters = new VehicleSearchParameters();

            parameters.TextBoxTerm = "Hy";

            var vehicles = repo.SearchUsedAvailableVehicles(parameters);
            Assert.AreEqual(2, vehicles.Count());

            var parameters2 = new VehicleSearchParameters();

            parameters2.MinPrice = 18000.00M;
            parameters2.MaxPrice = 33000.00M;

            var vehicles2 = repo.SearchUsedAvailableVehicles(parameters2);
            Assert.AreEqual(3, vehicles2.Count());

            var parameters3 = new VehicleSearchParameters();

            parameters3.MinYear = "2007";
            parameters3.MaxYear = "2008";

            var vehicles3 = repo.SearchUsedAvailableVehicles(parameters3);
            Assert.AreEqual(2, vehicles3.Count());

            var parameters4 = new VehicleSearchParameters();

            var vehicles4 = repo.SearchUsedAvailableVehicles(parameters4);
            Assert.AreEqual(3, vehicles4.Count());
        }

        [Test]
        public void CanLoadAvailableVehicles()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicles = repo.GetAllAvailable().ToList();

            Assert.AreEqual(6, vehicles.Count());
        }

        [Test]
        public void CanAddPurchase()
        {
            var repo = new PurchasesRepositoryADO();

            var purchase = new Purchase();
            purchase.PurchaseTypeId = 2;
            purchase.UserId = "00000000-0000-0000-0000-000000000000";
            purchase.Message = "VIN Test 2";
            purchase.CustomerInfoId = 2;
            purchase.Price = 20000.00M;

            repo.AddPurchase(purchase);
            var purchases = repo.GetAll().ToList();

            Assert.AreEqual(4, purchases.Count());
            Assert.AreEqual(4, purchase.PurchaseId);
            Assert.AreEqual(45000m, purchases[1].Price);
        }

        [Test]
        public void CanAddCustomer()
        {
            var repo = new CustomerInfoRepositoryADO();

            var customer = new CustomerInfo();
            customer.Name = "Testy Testerson";
            customer.Address1 = "321 Anywhere Lane";
            customer.City = "Charleston";
            customer.State = "SC";
            customer.Zip = "29401";
            customer.Phone = "555-5555";

            repo.AddCustomer(customer);
            var customers = repo.GetAll();

            Assert.AreEqual(4, customers.Count());
            Assert.AreEqual(4, customer.CustomerInfoId);
        }

        [Test]
        public void CanGetModelsByMakeId()
        {
            var repo = new ModelsRepositoryADO();

            var modelNames = repo.GetModelByMakeId(2).ToList();

            Assert.AreEqual(2, modelNames.Count());
            Assert.AreEqual("Forester", modelNames[0].ModelName);
            Assert.AreEqual("Outback", modelNames[1].ModelName);
        }

        [Test]
        public void CanGetMakesAndModels()
        {
            var repo = new ModelsRepositoryADO();

            var modelsAndMakes = repo.GetModelsAndMakes().ToList();

            Assert.AreEqual(6, modelsAndMakes.Count());

        }

        [Test]
        public void CanGetSalesUsers()
        {
            var repo = new VehiclesRepositoryADO();

            var users = repo.GetSalesUsers().ToList();

            Assert.AreEqual(2, users.Count());
            Assert.AreEqual("Chris Taggart", users[0].Name);
            Assert.AreEqual("ac3ece39-adf7-4823-bfc3-3ce5a42e8d0b", users[0].UserId);
        }

        [TearDown]
        public void ReInit()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
