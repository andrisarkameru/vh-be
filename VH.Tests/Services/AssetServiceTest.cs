using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VH.Data.EFCore;
using VH.Data.Repository;
using VH.Services.Interfaces;
using VH.Services.Services;

namespace VH.Tests
{
    public class AssetServiceTest : ServiceTestBase
    {
        private AssetRepository repo;
        private AssetService service;

        //Mock<AssetSer> assetServiceMock;
        [SetUp]
        public void Setup()
        {
            //Seed test data
            base.SeedTestAssets(_ctx);
            repo = new AssetRepository(_ctx);
            service = new AssetService(repo, _mapper);


        }

        [Test]
        public async Task ShoutReturnAll()
        {
            var assetsFromRepo = await repo.GetAll();

            assetsFromRepo.Should().HaveCount(2);

            var expectedCollection = new List<Asset>()
                {
                    new Asset(){ Id = 1, Type = "MotorVehicle", BasePrice = 66, Identification = "VH1233"},
                    new Asset(){  Id = 2,Type = "MotorVehicle",BasePrice = 99,Identification = "MTZ-2231",}
                };
            assetsFromRepo.Should().BeEquivalentTo(expectedCollection);
        }
        [Test]
        public async Task ShouldListAssets()
        {
            var assetsFromRepo = repo.GetAll();
            var serviceAssets = await service.ListAssets();
        }
    }
}
