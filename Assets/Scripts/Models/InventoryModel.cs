using System.Collections.Generic;
using cooking.Enum;
using Signals;

namespace Models
{
	public class InventoryModel
	{
		[Inject] public CurrencyChangeSignal CurrencyChangeSignal { get; set; }
		
		private Dictionary<Currency, int> _inventory = new Dictionary<Currency, int>();

		public void Add(Currency currency, int value)
		{
			if (_inventory.ContainsKey(currency))
			{
				_inventory[currency] += value;
			}
			else
			{
				_inventory.Add(currency, value);
			}
			
			CurrencyChangeSignal.Dispatch(currency, _inventory[currency]);
		}
		
		public bool Remove(Currency currency, int value)
		{
			if (_inventory.ContainsKey(currency))
			{
				if (_inventory[currency] >= value)
				{
					_inventory[currency] -= value;
					
					CurrencyChangeSignal.Dispatch(currency, _inventory[currency]);
					return true; 
				}
			}

			return false;
		}
		
		public int Value(Currency currency)
		{
			if (_inventory.ContainsKey(currency))
			{
				return _inventory[currency];
			}

			return 0;
		}
	}
}