using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

	namespace HomeWorkoutMAUI.Data
{
	public class CustomAuthenticationStateProvider : AuthenticationStateProvider
	{
		private readonly HttpClient _httpClient;

		public CustomAuthenticationStateProvider(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async override Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			User currentUser = await _httpClient.GetFromJsonAsync<User>("/Authorize/GetCurrentUser");

			if (currentUser != null && currentUser.Username != null)
			{
				//create a claim
				var claim = new Claim(ClaimTypes.Name, currentUser.Username);
				//create claimsIdentity
				var claimsIdentity = new ClaimsIdentity(new[] { claim },
					CookieAuthenticationDefaults.AuthenticationScheme);
				//create claimsPrincipal
				var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


				return new AuthenticationState(claimsPrincipal);
			}
			else
				return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
		}
	}
}
