# 10 things dotnet developers need to know while using CosmosDB API for NoSQL

## 1. What is CosmosDB and what is API for NoSQL? 

<img src="./assets/1.png" alt="CosmosDB Ecosystems">

- Fully managed database service – azure only
- Stores NoSQL, relational and vector data for AI
- You can perform reads and writes with single digit millisecond latency – client same azure region
- Global distribution – multi region, single master multi read, multi master multi read
- You get azure based availability 5 9s and security features like Entra and key vault integration
- Basically you're connecting to your data using an API

### Relational

Azure Cosmos DB also supports relational data models through its PostgreSQL API. This allows you to:
- **Use familiar SQL syntax**: Leverage your existing SQL skills.
- **Transactional support**: Ensure ACID transactions for your applications.
- **Integration with other Azure services**: Seamlessly integrate with Azure services like Azure Functions, Azure Logic Apps, and more⁴.

### Vector

Azure Cosmos DB has introduced vector database capabilities, which are particularly useful for AI and machine learning applications. Key features include:
- **Vector embeddings**: Store and manage high-dimensional vector embeddings for data like text, images, and audio.
- **Vector search**: Perform similarity searches using vector distance or similarity algorithms like DiskANN, which offers high recall and low latency¹².
- **Integrated approach**: Combine vector search with traditional NoSQL or relational queries to enhance data relevance and accuracy¹.

### NoSQL

Azure CosmosDB offers multiple APIs for NoSQL databases, including:
- Native API for NoSQL (focus of this repository)
- MongoDB
- Cassandra
- Gremlin
- Table

Multiple consistency models: Offers five consistency levels to balance between consistency and performance.
