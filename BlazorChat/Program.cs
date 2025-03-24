using ApplicationCore.Commons.Repository;
using ApplicationCore.Interfaces.UserService;
using ApplicationCore.Models;
using BlazorChat;
using BlazorChat.Components;
using Infrastructure.Memory;
using Infrastructure.Memory.Generators;
using Infrastructure.Memory.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();               
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<IGenericGenerator<int>,IntGenerator>();
builder.Services.AddSingleton<IGenericRepository<ChatUser, int>,MemoryGenericRepository<ChatUser, int>>();
builder.Services.AddSingleton<IChatUserService,ChatUserService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapHub<BlazorChatSampleHub>(BlazorChatSampleHub.HubUrl); 
app.Run();