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
// 쉽게 말하면 클라이언트와 서버가 인터넷(Http)을 통해 정보를 교환하기 위해 사용하는 인터페이스
// 자원을 이름으로 구분
// 자원의 상태를 주고 받는 모든 것

// Http 메소드를 Get으로 만들고
// api/inventory/allItem

// Http 메소드를 Del으로 만들고
// api/inventory/item

// Login을 하는 Api를 만든다고 하면
// 메소드는 ???
// api/account/login

// 계정 생성
// api/account/create

// 자원을 이름으로 구분
// Http Url로 자원을 명시를 합니다.

// Http Method(Post, Get, Put, Delete, Patch 등..)를 가지고 해당 자원에 대한 CRUD를 처리합니다.
// CRUD
//      - C : Create : 데이터 생성(Post)
//      - R : Read : 데이터 조회(Get)
//      - U : Update : 데이터 수정 (PUT, Patch)
//      - D : Delete : 데이터 삭제(Delete)


// swagger
// 개발자가 Rest 웹 서비스를 설계, 빌드, 문서화 하는데 도움을 주는 오픈소스 프레임 워크

// 숙제
// 계정 생성, 로그인을 만드는데, 중간중간 실패에 대한 응답을 클라한테 알려줄 수 있는 구조로 만들기



// NuGet 패키지에서 설치해야 되는 것
// Fomelo.EntityFrameWorkCore.MySql

//////////////////////////////////////////////////////////////
// 오늘 숙제
// 계정 생성 시, User 기본 정보도 만들어주기
// User 기본 데이터
//  - 플레이할 수 있는 캐릭터 아이디
//      - account_id(계정 ID)
//      - account_character(계정에서 가지고있는 캐릭터)
//  - 계정 생성 시, 기본으로 주어지는 Currency
//  - 닉네임

// 시간이 되면
//  - 닉네임 변경 기능 Api 만들기

// 대충 -> 정리 -> 잘

