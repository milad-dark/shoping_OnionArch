using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(long id)
        {
            return _context.Slides.Select(s => new EditSlide
            {
                Id = s.Id,
                BtnText = s.BtnText,
                Heading = s.Heading,
                Picture = s.Picture,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle,
                Text = s.Text,
                Title = s.Title,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SlideViewModel> GetList()
        {
            return _context.Slides.Select(s => new SlideViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Heading = s.Heading,
                Picture = s.Picture,
                IsRemoved = s.IsRemoved,
                CreationDate = s.CreationDate.ToFarsi(),
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
