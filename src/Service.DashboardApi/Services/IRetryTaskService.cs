using System;
using System.Threading.Tasks;

namespace Service.DashboardApi.Services
{
	public interface IRetryTaskService
	{
		ValueTask<bool> TaskInRetryStateAsync(Guid? userId, int unit, int task);

		bool CanRetryByTimeAsync(DateTime? progressDate, DateTime? lastRetryDate);

		ValueTask<DateTime?> GetRetryLastDateAsync(Guid? userId);

		ValueTask<bool> HasRetryCountAsync(Guid? userId);
	}
}