// See https://aka.ms/new-console-template for more information
using exchanges.Exchanges;
using System.Reflection;
using exchanges.Services;

var urls = new Dictionary<string, string>();

urls.Add("exchanges.Exchanges.binance", "https://api.binance.com/api/v3/ticker/bookTicker");
urls.Add("exchanges.Exchanges.bybit", "https://api.bybit.com/v2/public/tickers");
urls.Add("exchanges.Exchanges.kucoin", "https://api.kucoin.com/api/v1/market/allTickers");
urls.Add("exchanges.Exchanges.huobi", "https://api.huobi.pro/market/tickers");
urls.Add("exchanges.Exchanges.bitfinex", "https://api-pub.bitfinex.com/v2/tickers?symbols=ALL");
urls.Add("exchanges.Exchanges.coinsbit", "https://api.coinsbit.io/api/v1/public/tickers");
urls.Add("exchanges.Exchanges.mexc", "https://api.mexc.com/api/v3/ticker/24hr");
urls.Add("exchanges.Exchanges.bitget", "https://api.bitget.com/api/spot/v1/market/tickers");
urls.Add("exchanges.Exchanges.lbank", "https://api.lbkex.com/v2/ticker/24hr.do?symbol=all"); // уточнить получаемые данные
urls.Add("exchanges.Exchanges.bkex", "https://api.bkex.com/v2/q/ticker/price"); // уточнить получаемые данные, приходит только price
urls.Add("exchanges.Exchanges.bitmart", "https://api-cloud.bitmart.com/spot/v2/ticker");
urls.Add("exchanges.Exchanges.probit", "https://api.probit.com/api/exchange/v1/ticker");
urls.Add("exchanges.Exchanges.bittrex", "https://api.bittrex.com/v3/markets/tickers");
urls.Add("exchanges.Exchanges.okcoin", "https://www.okcoin.com/api/v5/market/tickers?instType=SPOT");
urls.Add("exchanges.Exchanges.poloniex", "https://api.poloniex.com/markets/ticker24h");
urls.Add("exchanges.Exchanges.exmo", "https://api.exmo.com/v1.1/ticker");
urls.Add("exchanges.Exchanges.bigone", "https://big.one/api/v3/asset_pairs/tickers");
urls.Add("exchanges.Exchanges.tapbit", "https://openapi.tapbit.com/spot/api/spot/instruments/ticker_list");
urls.Add("exchanges.Exchanges.bitmex", "https://www.bitmex.com/api/v1/instrument/active");
urls.Add("exchanges.Exchanges.bingx", "https://api-swap-rest.bingbon.pro/api/v1/market/getTicker");
urls.Add("exchanges.Exchanges.bitso", "https://sandbox.bitso.com/api/v3/ticker/");
urls.Add("exchanges.Exchanges.bitvavo", "https://api.bitvavo.com/v2/ticker/24h");
//urls.Add("exchanges.Exchanges.bitforex", "https://api.bitforex.com/api/v1/market/symbols"); // !здесь нет api по всем сразу валютам, сначала выбираются названия валют из <- ссылки, в конвертере по каждой валюте идёт отдельный запрос по данным
urls.Add("exchanges.Exchanges.pionex", "https://api.pionex.com/api/v1/market/tickers");
urls.Add("exchanges.Exchanges.coinstore", "https://api.coinstore.com/api/v1/market/tickers");
urls.Add("exchanges.Exchanges.indoex", "https://api.indoex.io/getMarketDetails/");
urls.Add("exchanges.Exchanges.tidex", "https://api.tidex.com/api/v1/public/tickers");
urls.Add("exchanges.Exchanges.azbit", "https://data.azbit.com/api/tickers"); // не уверен насчёт последней цены, взял price
urls.Add("exchanges.Exchanges.xtcom", "https://sapi.xt.com/v4/public/ticker"); // не нашёл описания данных, взял так: последняя цена - l, цена покупки - ap, цена продажи - bp
urls.Add("exchanges.Exchanges.latoken", "https://api.latoken.com/v2/ticker");
urls.Add("exchanges.Exchanges.biconomy", "https://www.biconomy.com/api/v1/tickers");
urls.Add("exchanges.Exchanges.cointr", "https://api.cointr.pro/v1/spot/market/tickers");
urls.Add("exchanges.Exchanges.consbit", "https://coinsbit.io/api/v1/public/tickers");


//urls.Add("exchanges.Exchanges.cracken", "https://api.kraken.com/0/public/OHLC?pair=XBTUSD"); // нет списка валют по api
//urls.Add("okx","https://www.okx.com/api/v5/market/tickers?instType=SPOT"); // не работает
//#"crypto": UnifyParser(url="https://api.crypto.com/v1/ticker/price", exchange="crypto", headers={"accept": "application/json", "content-type": "application/json"}); // bad request
//urls.Add("upbit","https://api.upbit.com/v1/ticker"); error 400
//#"bitrue": UnifyParser(url="https://www.bitrue.com/api/v1/ticker/allPrices", exchange="bitrue"); // не работает
//urls.Add("btcturk","https://api.btcturk.com/api/v2/ticker/currency?symbol=BTCUSDT"); откуда брать названия валют?
//urls.Add("deepcoin","https://api.deepcoin.com/deepcoin/market/tickers") // не работает;
//urls.Add("coinex","https://api.coinex.com/v1");  // не работает, нужна авторизация?
//#"phemex": UnifyParser(url="https://api.phemex.com/md/v1/ticker/24hr?symbol=<symbol>", exchange="phemex");
//#"currency": UnifyParser(url="https://marketcap.backend.currency.com/api/v1/token_crypto/", exchange="currency"); // не работает
//urls.Add("pexpay","https://api.pexpay.com/sapi/v1/c2c/ad/getReferencePrice");  // не работает
//urls.Add("woo","https://api.woo.org/"); нужна авторизация
//urls.Add("cryptology","https://sandbox.cryptology.com/v1/private/get-trades");   // не работает, нужна авторизация?
//urls.Add("garantex","https://garantex.io/api/v2/trades?market={BTCUSDT}"); // возвращает ~250 данных на одну валюту, какие надо брать?

var results = new exchangeResult();
var exportService = new ExportService();

foreach (var url in urls)
{
    HttpClient client = new HttpClient();
    HttpResponseMessage response = await client.GetAsync(url.Value);
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();

    Type type = Type.GetType(url.Key);
    var dto = Activator.CreateInstance(type);

    var serviceType = Type.GetType($"{url.Key}Map");
    var mapper = Activator.CreateInstance(serviceType);

    MethodInfo method = serviceType.GetMethod("Convert");
    method.Invoke(mapper, new object[] { results, responseBody });
}

exportService.GenerateJson(results);
exportService.GenerateExcel(results);