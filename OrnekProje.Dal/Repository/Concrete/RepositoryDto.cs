using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrnekProje.Dal.Context;
using OrnekProje.Dal.Repository.Abstract;
using OrnekProje.Model.DTOs.Response;
using OrnekProje.Model.Enums;
using OrnekProje.Model.Core;

namespace OrnekProje.Dal.Repository.Concrete
{
    public class RepositoryDto<TEntity, TEntityDto> : IRepositoryDto<TEntityDto>
        where TEntity : class, new()
        where TEntityDto : class, new()
    {
        private readonly OrnekProjeDbContext _context;
        private readonly DbSet<TEntity> _tentities;
        private readonly IMapper _mapper;

        public RepositoryDto(OrnekProjeDbContext context, IMapper mapper)
        {
            _context = context;
            _tentities = context.Set<TEntity>();
            _mapper = mapper;
        }
        
        // GetAll Metodu
        public async Task<ResponseDto<List<TEntityDto>>> GetAll()
        {
            try
            {
                var entities = await _tentities.AsNoTracking().ToListAsync();
                var dtos = _mapper.Map<List<TEntityDto>>(entities);

                return new ResponseDto<List<TEntityDto>>
                {
                    Data = dtos,
                    StatusCode = StatusCode.Success,
                    Messager = "Kayıtlar başarıyla getirildi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<TEntityDto>>
                {
                    Data = null,
                    StatusCode = StatusCode.Error,
                    Messager = "Kayıtlar alınırken hata oluştu: " + ex.Message
                };
            }
        }
        // GetById Metodu
        public async Task<ResponseDto<TEntityDto>> GetById(int id)
        {
            try
            {
                var entityType = typeof(TEntity);
                var entityName = entityType.Name;

                // ID özelliğini bul (Id veya {EntityName}Id olarak adlandırılmış olabilir)
                var idProperty = entityType.GetProperty("Id") ?? entityType.GetProperty($"{entityName}Id");
                if (idProperty == null || idProperty.PropertyType != typeof(int))
                {
                    throw new InvalidOperationException(
                        $"Entity {entityName} type int değil veya {entityName} Id özelliği bulunamadı.");
                }

                // ID'ye göre entity'yi bul
                var entity = await _tentities.IgnoreQueryFilters()
                    .FirstOrDefaultAsync(e => (int)idProperty.GetValue(e) == id);

                if (entity == null)
                {
                    return new ResponseDto<TEntityDto>
                    {
                        Data = null,
                        StatusCode = StatusCode.Warning, // Uyarı durumu için uygun bir kod
                        Messager = $"{id} numaralı kayıt bulunamadı."
                    };
                }

                // Entity'yi DTO'ya map et
                var dto = _mapper.Map<TEntityDto>(entity);

                return new ResponseDto<TEntityDto>
                {
                    Data = dto,
                    StatusCode = StatusCode.Success, // Başarılı işlem durumu
                    Messager = "Kayıt başarıyla getirildi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<TEntityDto>
                {
                    Data = null,
                    StatusCode = StatusCode.Error,
                    Messager = "Hata oluştu: " + ex.Message
                };
            }
        }
        
        // GetAllIgnoreFilter Metodu
        public async Task<ResponseDto<List<TEntityDto>>> GetAllIgnoreFilter()
        {
            try
            {
                var entities = await _tentities.IgnoreQueryFilters().AsNoTracking().ToListAsync();
                var dtos = _mapper.Map<List<TEntityDto>>(entities);

                return new ResponseDto<List<TEntityDto>>
                {
                    Data = dtos,
                    StatusCode = StatusCode.Success,
                    Messager = "Tüm kayıtlar başarıyla getirildi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<TEntityDto>>
                {
                    Data = null,
                    StatusCode = StatusCode.Error,
                    Messager = "Kayıtlar alınırken hata oluştu: " + ex.Message
                };
            }
        }
        
        // Delete Metodu
        public async Task<ResponseDto<TEntityDto>> Delete(int id)
        {
            try
            {
                var entityType = typeof(TEntity);
                var entityName = entityType.Name;

                // ID özelliğini bul (Id veya {EntityName}Id olarak adlandırılmış olabilir)
                var idProperty = entityType.GetProperty("Id") ?? entityType.GetProperty($"{entityName}Id");
                if (idProperty == null || idProperty.PropertyType != typeof(int))
                {
                    throw new InvalidOperationException(
                        $"Entity {entityName} type int değil veya {entityName} Id özelliği bulunamadı.");
                }

                // ID'ye göre entity'yi bul
                var entity = await _tentities.IgnoreQueryFilters()
                                             .FirstOrDefaultAsync(e => (int)idProperty.GetValue(e) == id);

                if (entity == null)
                {
                    return new ResponseDto<TEntityDto>
                    {
                        Data = null,
                        StatusCode = StatusCode.Warning,
                        Messager = $"{id} numaralı kayıt bulunamadı."
                    };
                }

                // Eğer entity EntityBase'den türemişse silme mantığını uygula
                if (entity is EntityBase entityBase)
                {
                    entityBase.IsDelete = true;
                    entityBase.DeleteAt = DateTime.UtcNow;
                    entityBase.DeleteBy = "System"; // Silen kullanıcı bilgisi buraya eklenebilir
                }

                // Değişiklikleri kaydet
                await _context.SaveChangesAsync();

                // Silinen entity'yi DTO'ya map et
                var deletedDto = _mapper.Map<TEntityDto>(entity);

                return new ResponseDto<TEntityDto>
                {
                    Data = deletedDto,
                    StatusCode = StatusCode.Success,
                    Messager = "Silme işlemi başarıyla tamamlandı."
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<TEntityDto>
                {
                    Data = null,
                    StatusCode = StatusCode.Error,
                    Messager = $"{id} numaralı kayıt silinirken bir veritabanı hatası oluştu: {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<TEntityDto>
                {
                    Data = null,
                    StatusCode = StatusCode.Error,
                    Messager = "Silme işlemi sırasında bir hata oluştu: " + ex.Message
                };
            }
        }
        
        public async Task<ResponseDto<TEntityDto>> Update(int id, TEntityDto updatedEntity)
{
    try
    {
        // Entity tipini al
        var entityType = typeof(TEntity);
        var entityName = entityType.Name;

        // ID özelliğini bul (Id veya {EntityName}Id olarak adlandırılmış olabilir)
        var idProperty = entityType.GetProperty("Id") ?? entityType.GetProperty($"{entityName}Id");
        if (idProperty == null || idProperty.PropertyType != typeof(int))
        {
            throw new InvalidOperationException(
                $"Entity {entityName} type int değil veya {entityName} Id özelliği bulunamadı.");
        }

        // ID'ye göre mevcut entity'yi bul
        var existingEntity = await _tentities.IgnoreQueryFilters()
                                             .FirstOrDefaultAsync(e => (int)idProperty.GetValue(e) == id);

        if (existingEntity == null)
        {
            return new ResponseDto<TEntityDto>
            {
                Data = null,
                StatusCode = StatusCode.Warning, // Uyarı durumu için uygun bir kod
                Messager = $"{id} numaralı kayıt bulunamadı."
            };
        }

        // DTO'dan gelen güncellenmiş veriyi mevcut entity'ye map et
        _mapper.Map(updatedEntity, existingEntity);

        // EntityBase alanlarını güncelle
        if (existingEntity is EntityBase entityBase)
        {
            entityBase.UpdateBy = "System"; // Güncelleyen kullanıcı bilgisi buraya eklenebilir
            entityBase.UpdateAt = DateTime.UtcNow;
        }

        // Değişiklikleri kaydet
        await _context.SaveChangesAsync();

        // Güncellenen entity'yi DTO'ya map et
        var updatedDto = _mapper.Map<TEntityDto>(existingEntity);

        return new ResponseDto<TEntityDto>
        {
            Data = updatedDto,
            StatusCode = StatusCode.Success, // Başarılı işlem durumu
            Messager = "Güncelleme işlemi başarıyla tamamlandı."
        };
    }
    catch (DbUpdateException ex)
    {
        // Veritabanı güncelleme hatası durumunda özel bir yanıt döndür
        return new ResponseDto<TEntityDto>
        {
            Data = null,
            StatusCode = StatusCode.Error,
            Messager = $"{id} numaralı kayıt güncellenirken bir veritabanı hatası oluştu: {ex.Message}"
        };
    }
    catch (Exception ex)
    {
        // Genel hata durumunda özel bir yanıt döndür
        return new ResponseDto<TEntityDto>
        {
            Data = null,
            StatusCode = StatusCode.Error,
            Messager = "Güncelleme işlemi sırasında bir hata oluştu: " + ex.Message
        };
    }
}
        
        // Create Metodu
        public async Task<ResponseDto<TEntityDto>> Create(TEntityDto entity)
        {
            try
            {
                // DTO'yu Entity'ye map et
                var newEntity = _mapper.Map<TEntity>(entity);

                // EntityBase alanlarını ayarla
                if (newEntity is EntityBase entityBase)
                {
                    entityBase.CreateBy = "System"; // Oluşturan kullanıcı bilgisi buraya eklenebilir
                    entityBase.CreateAt = DateTime.UtcNow;
                }

                // Yeni entity'yi ekleyip değişiklikleri kaydet
                await _tentities.AddAsync(newEntity);
                await _context.SaveChangesAsync();

                // Yeni entity'yi DTO'ya map et
                var createdDto = _mapper.Map<TEntityDto>(newEntity);

                return new ResponseDto<TEntityDto>
                {
                    Data = createdDto,
                    StatusCode = StatusCode.Success,
                    Messager = "Kayıt başarıyla oluşturuldu."
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<TEntityDto>
                {
                    Data = null,
                    StatusCode = StatusCode.Error,
                    Messager = "Kayıt oluşturulurken veritabanı hatası oluştu: " + ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<TEntityDto>
                {
                    Data = null,
                    StatusCode = StatusCode.Error,
                    Messager = "Kayıt oluşturulurken hata oluştu: " + ex.Message
                };
            }
        }

    }
}