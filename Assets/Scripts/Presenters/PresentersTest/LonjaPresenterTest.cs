using NSubstitute;
using NUnit.Framework;
using Presenters;
using UseCases;
using System;
using System.Collections.Generic;
using Models;

public class LonjaPresenterTest 
{
    IView view;
    LonjaPresenter presenter;
    ChangeMarketFishPrice changeMarketFishPrice;
    string martketName;
    string fishPrice;
    string fishName;
    string bestmarketName;


    [SetUp]
    public void Setup()
    {
        view = Substitute.For<IView>();
        presenter = new LonjaPresenter();
        presenter.Initialize(view);
    }
    [Test]
    public void OnFishMarketPriceChange_WhenMarketWithNameDoesntExist_CatchErrorAndSendToView()
    {
        WhenMarketNameThatDoesntExist();

        SendErrorToView();
    }

    [Test]
    public void OnBestMarket_WhenBestMarketDoesntExist_SendMessageToView()
    {
        WhenBestMarketDoesntExist();

        SendMessageToViewStartedWithProblem();
    }


    [Test]
    public void OnBestMarket_WhenBestMarketExist_SendMessageToView()
    {
        WhenBestMarketExist();

        SendMessageToViewWithBestMarketName();
    }

    private void WhenBestMarketExist()
    {
        view.OnFishMarketPriceChange += Raise.Event<Action<string, string, string>>("Vieiras", "Madrid", "400");
        view.OnFishMarketPriceChange += Raise.Event<Action<string, string, string>>("Pulpo", "Madrid", "400");
        view.OnFishMarketPriceChange += Raise.Event<Action<string, string, string>>("Centollos", "Madrid", "400");
        view.OnFishMarketPriceChange += Raise.Event<Action<string, string, string>>("Vieiras", "Barcelona", "400");
        view.OnFishMarketPriceChange += Raise.Event<Action<string, string, string>>("Pulpo", "Barcelona", "400");
        view.OnFishMarketPriceChange += Raise.Event<Action<string, string, string>>("Centollos", "Barcelona", "400");
        view.OnFishMarketPriceChange += Raise.Event<Action<string, string, string>>("Vieiras", "Lisboa", "10000");
        view.OnFishMarketPriceChange += Raise.Event<Action<string, string, string>>("Pulpo", "Lisboa", "10000");
        view.OnFishMarketPriceChange += Raise.Event<Action<string, string, string>>("Centollos", "Lisboa", "10000");
        view.OnBestMarket += Raise.Event<Action>();
        bestmarketName = "Lisboa";

    }

    private void SendMessageToViewWithBestMarketName()
    {
        view.Received().ShowMessageResult("El mercado con mas beneficio es: " + bestmarketName);
    }

    private void SendMessageToViewStartedWithProblem()
    {
        view.Received().ShowMessageResult("Problema:Ningun mercado da ganancias");
    }

    private void WhenBestMarketDoesntExist()
    {
        view.OnBestMarket += Raise.Event<Action>();
    }

    private void WhenMarketNameThatDoesntExist()
    {
        fishPrice = "500";
        fishName = "Pulpo";
        martketName = "MarketThatDoesntExist";
        view.OnFishMarketPriceChange += Raise.Event<Action<string, string, string>>(fishName, martketName, fishPrice);
    }
    private void SendErrorToView()
    {
        view.Received().ShowMessageResult(Arg.Any<string>());
    }

}
