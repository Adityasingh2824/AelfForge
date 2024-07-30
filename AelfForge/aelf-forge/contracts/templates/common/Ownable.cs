using AElf.Sdk.CSharp;
using AElf.Types;

public class OwnableContract : OwnableContractContainer.OwnableContractBase
{
    public override Empty Initialize(InitializeInput input)
    {
        State.Owner.Value = input.Owner;
        return new Empty();
    }

    public override Address GetOwner(Empty input)
    {
        return State.Owner.Value;
    }

    public override Empty TransferOwnership(Address input)
    {
        Assert(Context.Sender == State.Owner.Value, "Only the owner can transfer ownership.");
        State.Owner.Value = input;
        return new Empty();
    }

    // Example of an owner-only function
    public override Empty SomeOwnerOnlyFunction(Empty input)
    {
        Assert(Context.Sender == State.Owner.Value, "Only the owner can call this function.");
        // ... (your function logic here)
        return new Empty();
    }
}
