using Checkout.ApiServices.Cards.RequestModels;
using Checkout.ApiServices.Drinks.Model;
using Checkout.ApiServices.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.ApiServices.Drinks
{
    public class DrinkService
    {

        /// <summary>
        /// Assumptions:
        /// ==> Drinks will be part of overall project with other models
        /// ==> Drinks are a general item (no user, no cart)
        /// </summary>
        /// <param name="drinkRequest"></param>
        /// <returns></returns>


        public HttpResponse<Drink> AddDrink(Drink drinkRequest)
        {
            return new ApiHttpClient().PostRequest<Drink>(ApiUrls.Drinks, AppSettings.SecretKey, drinkRequest);
        }

        public HttpResponse<OkResponse> UpdateDrink(int drinkId, Drink drinkRequest)
        {
            var updateDrinkUri = string.Format(ApiUrls.Drink, drinkId);
            return new ApiHttpClient().PutRequest<OkResponse>(updateDrinkUri, AppSettings.SecretKey, drinkRequest);
        }

        public HttpResponse<Drink> GetDrinkFromName(string drinkName)
        {
            var getDrinkFromNameUri = string.Format(ApiUrls.GetDrinkFromName, drinkName);
            return new ApiHttpClient().GetRequest<Drink>(getDrinkFromNameUri, AppSettings.SecretKey);
        }

        public HttpResponse<OkResponse> DeleteDrink(int drinkId)
        {
            var deleteCardUri = string.Format(ApiUrls.Drink, drinkId);
            return new ApiHttpClient().DeleteRequest<OkResponse>(deleteCardUri, AppSettings.SecretKey);
        }

        public HttpResponse<List<Drink>> GetDrinkList()
        {
            return new ApiHttpClient().GetRequest<List<Drink>>(ApiUrls.Drinks, AppSettings.SecretKey);
        }
    }
}
