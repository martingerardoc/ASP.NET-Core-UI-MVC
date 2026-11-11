# dotnet-applications
# Assignment Submission Notes

**Repository:** [Insert your GitHub repository URL]

## 1. ASP.NET Core Web API – Pizza Operations

### Existing and Additional Pizzas

The application uses an ASP.NET Core Web API with controllers to manage pizza records.

The initial pizzas are:

- ID: 1 — Classic Italian
- ID: 2 — Veggie

**Additional pizza:**  
- ID: 3 — Pepperoni

**Evidence:**  
[Insert a screenshot showing the GET `/pizza` response with the existing pizzas and the additional pizza.]

### API Requests and Responses

The following requests demonstrate the four CRUD operations.

#### GET – Retrieve all pizzas

**Request:**
```http
GET http://localhost:5103/pizza
```

**Expected status code:** `200 OK`

**Response:**
```json
[
  {
    "id": 1,
    "name": "Classic Italian",
    "isGlutenFree": false
  },
  {
    "id": 2,
    "name": "Veggie",
    "isGlutenFree": true
  },
  {
    "id": 3,
    "name": "Pepperoni",
    "isGlutenFree": false
  }
]
```

**Evidence:** [Insert screenshot of the actual GET response.]

#### POST – Create a new pizza

**Request:**
```http
POST http://localhost:5103/pizza
Content-Type: application/json

{
  "name": "Hawaiian",
  "isGlutenFree": false
}
```

**Expected status code:** `201 Created`

**Expected response:**
```json
{
  "id": 4,
  "name": "Hawaiian",
  "isGlutenFree": false
}
```

**Evidence:** [Insert screenshot of the actual POST response.]

#### PUT – Update an existing pizza

**Request:**
```http
PUT http://localhost:5103/pizza/4
Content-Type: application/json

{
  "id": 4,
  "name": "Super Hawaiian",
  "isGlutenFree": false
}
```

**Expected status code:** `204 No Content`

**Response:** No response body is expected.

**Evidence:** [Insert screenshot of the actual PUT response.]

#### DELETE – Delete a pizza

**Request:**
```http
DELETE http://localhost:5103/pizza/4
```

**Expected status code:** `204 No Content`

**Response:** No response body is expected.

**Evidence:** [Insert screenshot of the actual DELETE response.]

---

## 2. Working with Files and Directories in a .NET App

The following function generates a sales summary report by reading the JSON sales files, calculating the total sales, and listing the individual sales total for each file.

### GenerateSalesSummaryReport Function

```csharp
static void GenerateSalesSummaryReport(
    IEnumerable<string> salesFiles,
    string reportPath)
{
    StringBuilder report = new StringBuilder();

    double totalSales = 0;

    var salesDetails = new List<(string FileName, double Total)>();

    // Read each sales file and calculate its total
    foreach (string salesFile in salesFiles)
    {
        string salesJson = File.ReadAllText(salesFile);

        SalesData? data =
            JsonConvert.DeserializeObject<SalesData>(salesJson);

        double fileTotal = data?.Total ?? 0;

        totalSales += fileTotal;

        salesDetails.Add((
            Path.GetFileName(salesFile),
            fileTotal
        ));
    }

    // Build the report
    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");
    report.AppendLine($" Total Sales: {totalSales:C}");
    report.AppendLine();
    report.AppendLine(" Details:");

    foreach (var detail in salesDetails)
    {
        report.AppendLine(
            $"  {detail.FileName}: {detail.Total:C}"
        );
    }

    // Save the report to a text file
    File.WriteAllText(reportPath, report.ToString());

    Console.WriteLine(
        $"Sales summary report created: {reportPath}"
    );
}
```

### Functionality

- `File.ReadAllText()` reads the contents of each JSON file.
- `JsonConvert.DeserializeObject()` converts JSON data into a `SalesData` object.
- `StringBuilder` constructs the sales summary report.
- `ToString("C")` formats the sales amounts as currency.
- `File.WriteAllText()` saves the generated report to a text file.

The report is saved as `sales-summary.txt` inside the `salesTotalDir` directory.

---

## 3. Repository

**GitHub Repository:** [Insert your repository URL]

The repository contains the working source code for both assignments:

1. ASP.NET Core Web API with pizza CRUD operations.
2. .NET application that reads sales files and generates a sales summary report.