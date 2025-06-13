using lanchonete.dto;
using lanchonete.dto.response;
using lanchonete.interfaces;
using lanchonete.model;

namespace lanchonete.service;

public class AdditionalService
{
    private readonly IAdditionalRepository _additionalRepository;

    public AdditionalService(IAdditionalRepository additionalRepository)
    {
        _additionalRepository = additionalRepository;
    }

    public async Task createAdditional(RequestCreateAdditionalDto dto)
    {
        await _additionalRepository.CreateAsync(new AdditionalModel(dto.name, dto.price));
    }

    public async Task<ResponseAdditionalDto> getAdditionalById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exception("id nao pode ser nulo ou vazio");
        }
        var additional = await _additionalRepository.GetByIdAsync(id);
        return new  ResponseAdditionalDto(id , additional.name, additional.price);
    }

    public async Task<ResponsePaginationAdditionalDto> getAllAdditional(int page, int size)
    {
        var additional = await _additionalRepository.GetAllAsync(page, size);
        
        var data = additional.Select(a => new ResponseAdditionalDto(a.id, a.name, a.price)).ToList();
        return new ResponsePaginationAdditionalDto(page, size, data);
        
    }

    public async Task updateAdditionalById(string id ,RequestUpdateAdditionalDto dto)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exception("id nao pode ser nulo ou vazio");
        }
        await _additionalRepository.UpdateAsync(id , new AdditionalModel(dto.name, dto.price));
    }

    public async Task deleteAdditionalById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exception("id nao pode ser nulo ou vazio");
        }
        await _additionalRepository.DeleteAsync(id);
    }
}