# .NET Backend Developer Project

## 📖 Project Description
This project was developed as part of the Botano Technologies hiring process. It provides an API for managing a card structure and is designed to meet the following requirements.

---

## 🛠️ Technologies and Tools
- **.NET 8** with CQRS architecture
- **Entity Framework Core**
- **Fluent Validation**
- **AutoMapper**
- **MediatR**
- **JwtBearer** authentication
- **PostgreSQL**
- **Swagger**

---

## 🚀 Features

- **Documentation written with Swagger**.

### GUID Implementation
- **GUIDs** are used for ID fields to ensure global uniqueness, security, and suitability for distributed systems.
- **Sequential GUIDs**: Improve performance and reduce database fragmentation.

### Database
- A remote PostgreSQL server is used for the database.
- Connection details are configured in the `appsettings.json` file of the API project.

### Enum Usage
- **CardStatus** is implemented as an enum to:
  - Ensure type safety.
  - Restrict values to a defined set.

---

## 🌐 API Endpoints

### Card Management
- **POST** `/api/card`: Adds a new card. All card data is sent in JSON format.
- **PUT** `/api/card`: Updates an existing card.
- **GET** `/api/card`: Lists all cards with their details.
- **GET** `/api/card/{id}`: Retrieves details of a specific card.

### Authentication
- Basic user login and registration endpoints are included.
- Authentication is handled using **JWT**.

### Additional Features
- **Marking Cards as "Done"**:
  - An API endpoint allows marking a card as "done."
  - Login is required to access this endpoint.
  - All active cards are accessible to all users.
  - Cards have a many-to-many relationship; when all questions in a card are answered, its status is updated to "done."

---

## 💡 Assumptions and Decisions
- Example data provided in the task document did not include `card id`, `questions id`, or `choices id`. These fields were added for operational purposes and to assist frontend developers.

---

## 🧪 Test User Information
You can log in using the test user credentials or create a new account.

- **Test User Credentials**:
  - Email: `codi@gmail.com`
  - Password: `123`

---

## 📂 Project Deployment and Access
- The project is hosted privately on my GitHub account: [smtdeveloper](https://github.com/smtdeveloper).
- Access has been granted to `admin@botano.com`.

---

## 📜 Notes
For any inquiries, please feel free to reach out to me via GitHub or email.

---

## 🔗 Connect with Me
- **LinkedIn**: [linkedin.com/in/bensametakca/](https://www.linkedin.com/in/bensametakca/)
- **Email**: [bensametakca@gmail.com](mailto:bensametakca@gmail.com)
- **Instagram**: [instagram.com/smtcoder/](https://www.instagram.com/smtcoder/) (My journey in the software world 🚀 Projects, tips and inspiring posts 🌟)

