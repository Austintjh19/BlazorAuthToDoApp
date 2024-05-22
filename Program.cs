using BlazorCascadingAuth.Components;
using BlazorCascadingAuth.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//.AddInteractiveServerComponents() Purpose: This extension method configures the services to support interactive server-side components. 
// This is part of Blazor Server, where components are executed on the server but updates are sent to the client over a SignalR connection.
// @rendermode InteractiveServer
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.Cookie.Name ="auth_token";
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/access-denied";
    });
// In simple terms, cookie authentication in Blazor involves storing a special token in a cookie on the user's browser after they log in. 
// This token is then sent back to the server with each request, allowing the server to verify the user's identity and grant access to protected resources.
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
// In a Blazor application, authentication state refers to whether a user is authenticated or not. This includes information such as the user's identity, roles, and any claims associated with their authentication.
// By adding cascading authentication state, you ensure that authentication-related information is available to all components within your application without explicitly passing it down through component parameters.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
// Anti-forgery tokens are a security feature used to prevent cross-site request forgery (CSRF) attacks. In a CSRF attack, an attacker tricks a user into unknowingly submitting a request to a web application that the user is authenticated with.
//  By doing this, the attacker can perform unauthorized actions on behalf of the user.
// The anti-forgery token validation middleware generates and validates tokens to ensure that each request comes from a trusted source and hasn't been tampered with by an attacker. 
//  It does this by including a unique token in each form rendered by the server and verifying that the token is present and valid when the form is submitted back to the server.
app.UseAuthentication();
// The UseAuthentication() method adds authentication middleware to the ASP.NET Core application pipeline.
// This middleware intercepts incoming requests and performs the necessary steps to authenticate the user, setting the appropriate identity on the request context. 
app.UseAuthorization();
// After authentication middleware has determined the user's identity, the authorization middleware checks whether the authenticated user is allowed to access the requested resource based on predefined authorization policies.

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
