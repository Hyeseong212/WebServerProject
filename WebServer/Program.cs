using WebServer.Repository;
using WebServer.Repository.Interface;
using WebServer.Repository.Shop;
using WebServer.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Set Service Singleton 
builder.Services.AddSingleton<AccountService, AccountService>();
builder.Services.AddSingleton<ShopService, ShopService>();

//Set DB Service Singleton
//builder.Services.AddSingleton<IAccountRepository, AccountRepositoryFromMemory>();
builder.Services.AddSingleton<IAccountRepository, AccountRepositoryFromMySql>();
builder.Services.AddSingleton<AccountDbContext, AccountDbContext>();

builder.Services.AddSingleton<IShopRepository, ShopRepositoryFromMySql>();
builder.Services.AddSingleton<ShopDbContext, ShopDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// Rest (Representational State Transfer) Api
// ���� ���ϸ� Ŭ���̾�Ʈ�� ������ ���ͳ�(Http)�� ���� ������ ��ȯ�ϱ� ���� ����ϴ� �������̽�
// �ڿ��� �̸����� ����
// �ڿ��� ���¸� �ְ� �޴� ��� ��

// Http �޼ҵ带 Get���� �����
// api/inventory/allItem

// Http �޼ҵ带 Del���� �����
// api/inventory/item

// Login�� �ϴ� Api�� ����ٰ� �ϸ�
// �޼ҵ�� ???
// api/account/login

// ���� ����
// api/account/create

// �ڿ��� �̸����� ����
// Http Url�� �ڿ��� ��ø� �մϴ�.

// Http Method(Post, Get, Put, Delete, Patch ��..)�� ������ �ش� �ڿ��� ���� CRUD�� ó���մϴ�.
// CRUD
//      - C : Create : ������ ����(Post)
//      - R : Read : ������ ��ȸ(Get)
//      - U : Update : ������ ���� (PUT, Patch)
//      - D : Delete : ������ ����(Delete)


// swagger
// �����ڰ� Rest �� ���񽺸� ����, ����, ����ȭ �ϴµ� ������ �ִ� ���¼ҽ� ������ ��ũ

// ����
// ���� ����, �α����� ����µ�, �߰��߰� ���п� ���� ������ Ŭ������ �˷��� �� �ִ� ������ �����



// NuGet ��Ű������ ��ġ�ؾ� �Ǵ� ��
// Fomelo.EntityFrameWorkCore.MySql

//////////////////////////////////////////////////////////////
// ���� ����
// ���� ���� ��, User �⺻ ������ ������ֱ�
// User �⺻ ������
//  - �÷����� �� �ִ� ĳ���� ���̵�
//      - account_id(���� ID)
//      - account_character(�������� �������ִ� ĳ����)
//  - ���� ���� ��, �⺻���� �־����� Currency
//  - �г���

// �ð��� �Ǹ�
//  - �г��� ���� ��� Api �����

// ���� -> ���� -> ��

