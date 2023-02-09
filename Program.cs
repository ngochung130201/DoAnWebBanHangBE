using DoAnBE.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DoAnBE.Repository.menu;
using DoAnBE.Repository.silider;
using DoAnBE.Repository.about;
using DoAnBE.Repository.brand;
using DoAnBE.Repository.contact;
using DoAnBE.Repository.feedback;
using DoAnBE.Repository.post;
using DoAnBE.Repository.supplier;
using DoAnBE.Repository.invoice;
using DoAnBE.Repository.member;
using DoAnBE.Repository.customer;
using DoAnBE.Repository.order;
using DoAnBE.Repository.orderDetail;
using DoAnBE.Repository.postCategory;
using DoAnBE.Repository.postComment;
using DoAnBE.Repository.productCategory;
using DoAnBE.Repository.product;
using DoAnBE.Repository.productComment;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build => {
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddDbContext<ComputerdbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DoAnAPI")), ServiceLifetime.Transient);
builder.Services.AddAutoMapper(typeof(Program));
//life cycle DI: AddSingleton(),addTransient,addScoped
//builder.Services.AddScoped<IMenu, MenuRes>();
//life cycle DI: AddSingleton(),addTransient,addScoped
builder.Services.AddScoped<IMenu, MenuRes>();
builder.Services.AddScoped<ISilider, SiliderRes>();
builder.Services.AddScoped<IAbout, AboutRes>();
builder.Services.AddScoped<IBrand, BrandRes>();
builder.Services.AddScoped<IContact, ContactRes>();
builder.Services.AddScoped<IFeedback, FeedbackRes>();
builder.Services.AddScoped<IPost, PostRes>();
builder.Services.AddScoped<ISupplier, SupplierRes>();
builder.Services.AddScoped<IInvoice, InvoiceRes>();
builder.Services.AddScoped<IMember, MemberRes>();
builder.Services.AddScoped<ICustomer, CustomerRes>();
builder.Services.AddScoped<IOrder, OrderRes>();
builder.Services.AddScoped<IOrderDetail, OrderDetailRes>();
builder.Services.AddScoped<IPostCategory, PostCategoryRes>();
builder.Services.AddScoped<IPostComment, PostCommentRes>();
builder.Services.AddScoped<IProductCategory, ProductCategoryRes>();
builder.Services.AddScoped<IProduct, ProductRes>();
builder.Services.AddScoped<IProductComment, ProductCommentRes>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("corspolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
