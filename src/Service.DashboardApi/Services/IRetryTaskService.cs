using System;
using System.Threading.Tasks;

namespace Service.DashboardApi.Services
{
	public interface IRetryTaskService
	{
		ValueTask<bool> TaskInRetryStateAsync(Guid? userId, int unit, int task);

		ValueTask<bool> CanRetryByTimeAsync(Guid? userId, DateTime? progressDate);

		ValueTask<bool> HasRetryCountAsync(Guid? userId);
	}
}