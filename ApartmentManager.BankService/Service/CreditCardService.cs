using ApartmentManager.BankService.Configuration;
using ApartmentManager.BankService.Model.Mongo;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.BankService.Service
{
    public class CreditCardService : ICreditCardService
    {
        IMongoCollection<CreditCard> _creditCardCollection;
        MongoDbConfiguration _config;
        public CreditCardService(IOptions<MongoDbConfiguration> config)
        {
            _config = config.Value;
            MongoClient mongoClient = new MongoClient(_config.ConnectionString);
            var database = mongoClient.GetDatabase(_config.Database);
            _creditCardCollection = database.GetCollection<CreditCard>("CreditCard");

        }

        public async Task<bool> WithdrawMoney(CreditCard creditCard, int money)
        {

            var current = await _creditCardCollection.Find(x => x.CardNumber == creditCard.CardNumber && x.Cvv == creditCard.Cvv
              && x.Owner == creditCard.Owner && x.ValidMonth == creditCard.ValidMonth && x.ValidYear == creditCard.ValidYear)
                  .FirstOrDefaultAsync();

            if (current != null && current.Balance >= money)
            {
                current.Balance -= money;

                await _creditCardCollection.ReplaceOneAsync(x => x.Id == current.Id, current);

                return true;
            }

            return false;
        }
    }
}
