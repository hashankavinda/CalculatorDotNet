using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly IMemoryCache _cache;
        private readonly string cacheNumberOne = "numberOne";
        private readonly string cacheNumberTwo = "numberTwo";
        private readonly string cacheOperator = "operator";
        private readonly string cacheKey = "cacheKey";

        public CalculatorController(ILogger<CalculatorController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel cm, string btnName)
        {
            bool hasNumberOne = _cache.TryGetValue(cacheNumberOne, out double numberOneValue);
            bool hasNumberTwo = _cache.TryGetValue(cacheNumberTwo, out double numberTwoValue);
            bool hasOperator = _cache.TryGetValue(cacheOperator, out double operatorValue);

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(100))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(100))
                    .SetPriority(CacheItemPriority.Normal);

            switch (btnName)
            {
                case ("0"):
                case ("1"):
                case ("2"):
                case ("3"):
                case ("4"):
                case ("5"):
                case ("6"):
                case ("7"):
                case ("8"):
                case ("9"):
                case ("00"):
                case ("."):
                    if(!hasOperator)
                    {
                        SetNumberOne(btnName, cm, hasNumberOne, hasNumberTwo, hasOperator, cacheEntryOptions);
                    }
                    else
                    {
                        SetNumberTwo(btnName, cm, hasNumberOne, hasNumberTwo, hasOperator, cacheEntryOptions);
                    }
                    break;
                case ("add"):
                    break;
                case ("sub"):
                    break;
                case ("mul"):
                    break;
                case ("div"):
                    break;
                case ("clear"):
                    break;
                case ("delete"):
                    break;
                case ("allClear"):
                    break;
                default:
                    break;
            }

            //if (!hasNumberOne)
            //{
            //    cm.Placeholder = btnName;
            //    _cache.Set(cacheNumberOne, cm.Placeholder, cacheEntryOptions);
            //}
            //else if (hasNumberOne && !hasOperator)
            //{
            //    cm.Placeholder += btnName;
            //    _cache.Set(cacheNumberOne, cm.Placeholder, cacheEntryOptions);
            //}
            //else if (hasNumberOne && hasOperator && !hasNumberTwo)
            //{
            //    cm.Placeholder = btnName;
            //    _cache.Set(cacheOperator, cm.Placeholder, cacheEntryOptions);
            //}
            //else if (hasNumberOne && hasOperator && hasNumberTwo)
            //{
                
            //}

            //var cacheEntryOptions = new MemoryCacheEntryOptions()
            //        .SetSlidingExpiration(TimeSpan.FromSeconds(100))
            //        .SetAbsoluteExpiration(TimeSpan.FromSeconds(100))
            //        .SetPriority(CacheItemPriority.Normal);

            //switch (btnName)
            //{
            //    case ("zero"):
            //        break;
            //    case ("one"):
            //        break;
            //    case ("two"):
            //        break;
            //    case ("three"):
            //        break;
            //    case ("four"):
            //        break;
            //    case ("five"):
            //        break;
            //    case ("six"):
            //        break;
            //    case ("seven"):
            //        break;
            //    case ("eight"):
            //        break;
            //    case ("nine"):
            //        break;
            //    case ("."):
            //        break;
            //    case ("add"):
            //        break;
            //    case ("sub"):
            //        break;
            //    case ("mul"):
            //        break;
            //    case ("div"):
            //        break;
            //    default:
            //        break;
            //}

            if (btnName.Equals("1"))
            {
                cm.NumberOne = cm.NumberOne + 1;
                cm.Placeholder = cm.Placeholder + 1;

                //if (!_cache.trygetvalue(cachenumberone, out double numberonevalue))
                //{
                //    //cm.placeholder = numberonevalue.tostring();
                //    _cache.set(cachenumberone, double.parse(btnname), cacheentryoptions);
                //}
                //else if (numberonevalue != null)
                //{
                //    cm.placeholder += numberonevalue;
                //}

                if (_cache.TryGetValue(cacheKey, out double cacheKeyValue))
                {
                    cm.Placeholder += cacheKeyValue;
                }

                

                //var cacheEntryOptions = new MemoryCacheEntryOptions()
                //    .SetSlidingExpiration(TimeSpan.FromSeconds(100))
                //    .SetAbsoluteExpiration(TimeSpan.FromSeconds(100))
                //    .SetPriority(CacheItemPriority.Normal);

                _cache.Set(cacheKey, cm.Placeholder, cacheEntryOptions);
                //_cache.Remove(cacheNumberOne);
            }
            return View(cm);
        }

        private void SetNumberOne(
            string btnName, 
            CalculatorModel cm, 
            bool hasNumberOne, 
            bool hasNumberTwo,
            bool hasOperator, 
            MemoryCacheEntryOptions cacheEntryOptions
        )
        {
            if (!hasNumberOne)
            {
                cm.Placeholder = btnName;
                _cache.Set(cacheNumberOne, cm.Placeholder, cacheEntryOptions);
            }
            else if (hasNumberOne && !hasOperator)
            {
                cm.Placeholder += btnName;
                _cache.Set(cacheNumberOne, cm.Placeholder, cacheEntryOptions);
            }
            else if (hasNumberOne && hasOperator && !hasNumberTwo)
            {
                cm.Placeholder = btnName;
                _cache.Set(cacheOperator, cm.Placeholder, cacheEntryOptions);
            }
            else if (hasNumberOne && hasOperator && hasNumberTwo)
            {

            }
            else
            {
                cm.Placeholder = btnName;
            }

            //switch (btnName)
            //{
            //    case ("0"):
            //        break;
            //    case ("1"):
            //        break;
            //    case ("2"):
            //        break;
            //    case ("3"):
            //        break;
            //    case ("4"):
            //        break;
            //    case ("5"):
            //        break;
            //    case ("6"):
            //        break;
            //    case ("7"):
            //        break;
            //    case ("8"):
            //        break;
            //    case ("9"):
            //        break;
            //    case ("00"):
            //        break;
            //    case ("."):
            //        break;
            //    case ("add"):
            //        break;
            //    case ("sub"):
            //        break;
            //    case ("mul"):
            //        break;
            //    case ("div"):
            //        break;
            //    case ("clear"):
            //        break;
            //    case ("delete"):
            //        break;
            //    case ("allClear"):
            //        break;
            //    default:
            //        break;
            //}
        }

        private void SetNumberTwo(
            string btnName,
            CalculatorModel cm,
            bool hasNumberOne,
            bool hasNumberTwo,
            bool hasOperator,
            MemoryCacheEntryOptions cacheEntryOptions
        )
        {

        }
    }
}
