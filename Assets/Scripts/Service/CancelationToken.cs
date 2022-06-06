using System.Threading;

namespace Game.Services
{
	public class CancellationTokenService
	{
		private CancellationTokenSource _cancellationTokenSource;

		public CancellationTokenService()
		{
			_cancellationTokenSource = new CancellationTokenSource();
		}

		public bool IsCanceled()
		{
			return _cancellationTokenSource.IsCancellationRequested;
		}

		public void Cancel()
		{
			_cancellationTokenSource.Cancel();
		}

		public void Reset()
		{
			_cancellationTokenSource = new CancellationTokenSource();
		}
	}
}