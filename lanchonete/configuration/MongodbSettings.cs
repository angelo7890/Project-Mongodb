﻿namespace lanchonete.configuration;

public class MongodbSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}