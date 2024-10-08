using Azure.Identity;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSingleton<CosmosClient>((_) =>
    {
        // <create_client>
        // create client with connection strings
        CosmosClient client = new(
            accountEndpoint: builder.Configuration["AZURE_COSMOS_DB_NOSQL_ENDPOINT"]!,
            authKeyOrResourceToken: builder.Configuration["AZURE_COSMOS_DB_NOSQL_KEY"]
        );
        // </create_client>

        return client;
    });
}
else
{
    builder.Services.AddSingleton<CosmosClient>((_) =>
    {
        // <create_client_client_id>
        CosmosClient client = new(
            accountEndpoint: builder.Configuration["AZURE_COSMOS_DB_NOSQL_ENDPOINT"]!,
            tokenCredential: new DefaultAzureCredential(
                new DefaultAzureCredentialOptions()
                {
                    ManagedIdentityClientId = builder.Configuration["AZURE_MANAGED_IDENTITY_CLIENT_ID"]!
                }
            )
        );
        // </create_client_client_id>
        return client;
    });
}

builder.Services.AddTransient<ICosmosDbService, CosmosDbService>();

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
