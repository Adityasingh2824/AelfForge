# AelfForge
# aelf forge Project Management Toolkit

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Python 3.x](https://img.shields.io/badge/python-3.x-blue.svg)](https://www.python.org/downloads/)

## Project Overview

This toolkit is a powerful suite of Python scripts designed to simplify the entire lifecycle of smart contract development on the aelf blockchain. By automating key processes and leveraging AI-driven insights, it enhances productivity, code quality, and maintainability for aelf developers.

**Key Problem Solved:**

Developing and maintaining complex smart contracts can be a challenging and error-prone process. This toolkit aims to alleviate those challenges by:

- **Reducing manual effort:** Automating repetitive tasks like project setup, deployment, and basic interactions.
- **Improving code quality:** Providing code analysis tools to identify potential vulnerabilities and enhance readability.
- **Enhancing documentation:** Utilizing natural language processing (NLP) to extract meaningful insights from code comments, making documentation more informative.
- **Streamlining configuration:** Simplifying the management of project settings and credentials.

## How It Works

The toolkit leverages a modular architecture with several specialized scripts:

1. **Scaffolding (`scaffold.py`):**
   - Automatically creates a standardized project structure with boilerplate code for aelf contracts.
   - Helps new developers get started quickly and ensures a consistent codebase.

2. **Compilation & Deployment (`deploy.py`):**
   - Streamlines the process of compiling your smart contracts into deployable bytecode.
   - Provides a simple interface for deploying contracts to the aelf blockchain.

3. **Contract Interaction (`utils.py`):**
   - Offers convenient functions to interact with deployed contracts, including calling methods and querying state variables.

4. **Code Analysis (`code_analysis.py`):**
   - Employs static analysis tools like `radon` and `lizard` to assess code complexity and identify potential issues like vulnerabilities, anti-patterns, and excessive complexity.

5. **NLP-Powered Documentation (`nlp_utils.py`):**
   - Employs the spaCy NLP library to extract keywords from your contract comments.
   - Helps developers quickly understand the purpose and functionality of different parts of the code.
   - Encourages better documentation practices.

6. **Configuration (`config.py`):**
   - Centralizes project settings in a single file.
   - Utilizes environment variables (`.env` file) to store sensitive information like API keys and passwords securely.

## AI Integration

The toolkit integrates AI technology in two key ways:

1. **Natural Language Processing (NLP):**
   - Leverages spaCy's NLP capabilities to extract keywords and analyze the sentiment of code comments. This helps identify areas that might need better documentation or attention.

2. **Code Analysis (Future Potential):**
   - While not implemented yet, there's potential to integrate AI-powered code analysis tools to automatically identify more complex security vulnerabilities and code patterns.

## Google Cloud Platform (GCP) Integration (Future Potential)

The toolkit can be enhanced to leverage GCP in several ways:

- **Cloud Functions:** Deploying the toolkit as serverless Cloud Functions would allow you to create a web interface or API for easier access.
- **BigQuery:** Store code analysis results in BigQuery for historical tracking and more comprehensive analysis using SQL-like queries.
- **Natural Language API:** Enhance NLP capabilities by utilizing Google's Natural Language API for more sophisticated text analysis.

## Getting Started

1.  **Prerequisites:**
    - Python 3.x
    - `pip` package manager
    - Git
    - (Optional) A Google Cloud Platform project

2.  **Installation:**

    ```bash
    git clone [https://github.com/](https://github.com/)<your-username>/<your-repo-name>.git
    cd <your-repo-name> 
    python -m venv venv
    source venv/bin/activate  # On Linux/macOS
    venv\Scripts\activate     # On Windows
    pip install -r requirements.txt
    python -m spacy download en_core_web_sm
    ```

3.  **Configuration:**
    - Create a `.env` file in the project root directory and add your configuration settings.
    - See the `config.py` file for details on the required environment variables.

4.  **Usage:**
    - Refer to the **Usage** section in this README for examples of how to use the toolkit's commands.


## Contributing

We welcome contributions! Please feel free to open issues or submit pull requests.

## License

This project is licensed under the MIT License - see the `LICENSE` file for details.
