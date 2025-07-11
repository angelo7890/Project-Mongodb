﻿using lanchonete.model;

namespace lanchonete.interfaces;

public interface IAdditionalRepository
{
    Task<List<AdditionalModel>> GetAllAsync(int pageNumber, int pageSize);
    Task<AdditionalModel?> GetByIdAsync(string id);
    Task CreateAsync(AdditionalModel additional);
    Task UpdateAsync(string id, AdditionalModel additional);
    Task DeleteAsync(string id);
    
}