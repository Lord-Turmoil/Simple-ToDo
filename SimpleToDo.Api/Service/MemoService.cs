using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using SimpleToDo.Api.Context;
using SimpleToDo.Shared.Dtos;

namespace SimpleToDo.Api.Service
{
	public class MemoService : EntityService<Memo, MemoDto>
	{
		public MemoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
		{
		}

		public override async Task<ApiResponse> UpdateAsync(MemoDto model)
		{
			try
			{
				var dbMemo = _mapper.Map<Memo>(model);
				var repo = _unitOfWork.GetRepository<Memo>();
				var memo = await repo.GetFirstOrDefaultAsync(predicate: x => x.ID.Equals(dbMemo.ID));

				memo.Title = dbMemo.Title;
				memo.Content = dbMemo.Content;
				memo.UpdatedTime = DateTime.Now;
				repo.Update(memo);

				if (await _unitOfWork.SaveChangesAsync() > 0)
					return new ApiResponse(memo);
				return new ApiResponse("Failed to update memo");
			}
			catch (Exception ex)
			{
				return new ApiResponse(ex.Message);
			}
		}
	}
}
