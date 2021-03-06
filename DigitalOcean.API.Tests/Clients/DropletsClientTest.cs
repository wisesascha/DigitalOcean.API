﻿using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class DropletsClientTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<Droplet>("droplets", null, "droplets");
        }

        [Fact]
        public void CorrectRequestForGetKernels() {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.GetKernels(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().GetPaginated<Kernel>("droplets/{id}/kernels", parameters, "kernels");
        }

        [Fact]
        public void CorrectRequestForGetSnapshots() {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.GetSnapshots(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().GetPaginated<Image>("droplets/{id}/snapshots", parameters, "snapshots");
        }

        [Fact]
        public void CorrectRequestForGetBackups() {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.GetBackups(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().GetPaginated<Image>("droplets/{id}/backups", parameters, "backups");
        }

        [Fact]
        public void CorrectRequestForGetActions() {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.GetActions(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().GetPaginated<Action>("droplets/{id}/actions", parameters, "actions");
        }

        [Fact]
        public void CorrectRequestForCreate() {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            var body = new Models.Requests.Droplet();
            client.Create(body);

            factory.Received().ExecuteRequest<Droplet>("droplets", null, body, "droplet", Method.POST);
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.Get(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().ExecuteRequest<Droplet>("droplets/{id}", parameters, null, "droplet");
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.Delete(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().ExecuteRaw("droplets/{id}", parameters, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForGetUpgrades() {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.GetUpgrades();

            factory.Received().GetPaginated<DropletUpgrade>("droplet_upgrades", null);
        }
    }
}