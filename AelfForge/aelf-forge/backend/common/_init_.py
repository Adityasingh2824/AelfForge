# __init__.py

# Import functions you want to expose from your scripts
from .scaffold import (
    create_project,
    compile_contracts,
    deploy_contracts,
    generate_contract,
)
from .deploy import deploy_contracts
from .utils import (
    call_contract_method,
    get_contract_state,
    encode_parameters,
    decode_result,
)
from .code_analysis import scan_contracts
from .nlp_utils import (
    extract_keywords,
    analyze_comments,
    analyze_user_input,
)
# Import from other scripts as needed...

# You can also define variables, classes, or other objects here
__all__ = [
    "create_project",
    "compile_contracts",
    "deploy_contracts",
    "generate_contract",
    "call_contract_method",
    "get_contract_state",
    "encode_parameters",
    "decode_result",
    "scan_contracts",
    "extract_keywords",
    "analyze_comments",
    "analyze_user_input",
    # ... Add other names you want to expose
]
