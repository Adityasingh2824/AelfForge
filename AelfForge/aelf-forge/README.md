Markdown
# aelf forge Project Management Toolkit

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

This toolkit is a collection of Python scripts designed to streamline the development, testing, deployment, and analysis of smart contracts on the aelf forge blockchain platform.

## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Configuration](#configuration)
- [Scripts](#scripts)
- [Contributing](#contributing)
- [License](#license)   


## Features

- **Scaffolding:** Quickly set up a new aelf forge project structure with boilerplate code and configuration files.
- **Compilation and Deployment:** Compile and deploy your smart contracts to the aelf blockchain.
- **Contract Interaction:** Call methods and query state variables of deployed contracts.
- **Code Analysis:** Analyze your code for complexity, potential vulnerabilities, and style issues using `radon` and `lizard`.
- **Natural Language Processing (NLP) Analysis:** Extract keywords and analyze comments in your contracts using `spaCy`.
- **Configuration:** Easily manage project settings and sensitive information using a `config.py` file and environment variables.

## Installation

1. **Clone the Repository:**
   ```bash
   git clone [https://github.com/](https://github.com/)<your-username>/<your-repo-name>.git
Use code with caution.

Create a Virtual Environment (Recommended):

Bash
python -m venv venv
source venv/bin/activate  # On Linux/macOS
venv\Scripts\activate     # On Windows
Use code with caution.

Install Dependencies:

Bash
pip install -r requirements.txt
Use code with caution.

Download spaCy Model:

Bash
python -m spacy download en_core_web_sm
Use code with caution.

Usage
Run the main.py script with various arguments to perform different tasks. Here are some examples:

Create a new project named "my_dapp":
Bash
python main.py my_dapp --create
Use code with caution.

Compile and deploy contracts in the "my_dapp" project:
Bash
python main.py my_dapp --compile --deploy
Use code with caution.

Analyze code and comments in the "my_dapp" project:
Bash
python main.py my_dapp --analyze-code --analyze-comments
Use code with caution.

Call the "vote" method on the "voting" contract with parameters:
Bash
python main.py my_dapp --call voting vote '{"proposal_id": 1, "option": "yes"}'
Use code with caution.

Get the value of the "proposal_count" state variable in the "voting" contract:
Bash
python main.py my_dapp --get-state voting proposal_count
Use code with caution.

For a complete list of commands and options, run:

Bash
python main.py --help
Use code with caution.

Configuration
Create a .env file in your project's root directory.
Set the following environment variables (replace with your actual values):
NODE_URL: URL of your aelf node
ACCOUNT_ADDRESS: Your aelf account address
ACCOUNT_PASSWORD: Your aelf account password
*_CONTRACT_ADDRESS: Addresses of your deployed contracts (e.g., VOTING_CONTRACT_ADDRESS)
Scripts
main.py: The main entry point for the toolkit.
scaffold.py: Handles project creation and contract scaffolding.
deploy.py: Compiles and deploys contracts.
utils.py: Provides helper functions for blockchain interaction.
code_analysis.py: Analyzes code complexity and style.
nlp_utils.py: Extracts keywords and analyzes comments in contracts.
config.py: Manages project configuration.
__init__.py: Makes the toolkit functions available as a package.
Contributing
Contributions are welcome! Feel free to open issues or submit pull requests.

License
This project is licensed under the MIT License. See the LICENSE file for details.   


**Key Improvements:**

- **Clear Project Title and Description:** Concisely describes the project's purpose.
- **Badge:** Adds a license badge for quick reference.
- **Installation Instructions:** Provides step-by-step guidance for setting up the project.
- **Detailed Usage Examples:** Demonstrates how to use the script's features.
- **Organized Structure:** Presents information in a clear and logical way.
- **Contributing Guidelines:** Encourages community involvement.