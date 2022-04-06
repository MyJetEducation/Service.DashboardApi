using System;
using System.Threading.Tasks;

namespace Service.WalletApi.DashboardApi.Services
{
	public interface IRetryTaskService
	{
		ValueTask<bool> TaskInRetryStateAsync(string userId, int unit, int task);

		bool CanRetryByTimeAsync(DateTime? progressDate, DateTime? lastRetryDate);

		ValueTask<DateTime?> GetRetryLastDateAsync(string userId);

		ValueTask<bool> HasRetryCountAsync(string userId);
	}
}