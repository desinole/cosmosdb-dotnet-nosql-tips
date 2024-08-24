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

## 2. Should I move all my data to CosmosDB immediately?

### Use Cases

- High availability, low latency, and scalability: Applications that require fast access to user data, session management, and real-time updates.
- Internet of Things (IoT) and Telematics: IoT devices generate massive amounts of data that need to be ingested, processed, and analyzed in real-time.
- Retail and Marketing: Retail applications often require real-time inventory management, personalized customer experiences, and transaction processing.
- Gaming: Online games need to manage player data, leaderboards, and game state in real-time. 

### Read-heavy workloads

- Characteristics
  - Frequent reads (e.g. reports): These workloads involve a high volume of read operations compared to write operations.
  - Query heavy: Users expect quick responses to their queries.
- Challenges
  - Getting indexing correct: Indexing is crucial for query performance.
  - Query optimization: Queries should be optimized for performance.
  - Volume: Complex queries can slow down the system as dataset size grows.

### Write-heavy workloads

- Characteristics
  - Frequent writes (e.g. IoT sensor data): These workloads involve a high volume of write operations, such as logging, telemetry, or real-time data ingestion
  - Data Integrity: Ensuring that all writes are accurately recorded and that data integrity is maintained.
  - Throughput: The system must handle a high throughput of write operations without significant delays..
- Challenges
  - Disk I/O bottleneck: High write volumes can overwhelm disk I/O, leading to performance degradation.
  - Lock contention: Concurrent write operations may contend for locks on database resources, causing slowdowns.
  - Index creation: Maintaining indexes on heavily written tables can incur additional overhead.

### Migrate relational to NoSQL data

- Use data migration but in small batches - think [Stangler Fig Pattern](https://en.wikipedia.org/wiki/Strangler_fig_pattern): The Strangler Fig pattern is a strategy for gradually migrating a legacy system to a new architecture by incrementally replacing specific pieces of functionality. This minimizes risk and ensures continuous operation during the migration process.
- Identify Components: Determine which parts of the legacy system can be replaced first.
- Create a Façade: Implement a façade that intercepts requests to the legacy system and routes them to either the old or new system based on the functionality being accessed
- Incremental Replacement: Gradually replace legacy components with new services. The façade ensures that users continue to interact with the system seamlessly.
- Decommission Legacy Data: Once all components have been replaced, the legacy system can be safely decommissioned.