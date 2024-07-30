using AElf.Sdk.CSharp;
using AElf.Types;
using Google.Protobuf.WellKnownTypes;

public class VotingContract : VotingContractContainer.VotingContractBase
{
    private readonly MapToUInt64<Hash> _proposals = new MapToUInt64<Hash>();
    private readonly MapToUInt64<Address> _voters = new MapToUInt64<Address>();

    public override Empty CreateProposal(ProposalInput input)
    {
        var proposalHash = HashHelper.ComputeFrom(input);
        Assert(!_proposals.ContainsKey(proposalHash), "Proposal already exists.");
        _proposals[proposalHash] = State.ProposalCount.Value;
        State.ProposalCount.Value = State.ProposalCount.Value + 1;
        return new Empty();
    }

    public override Empty Vote(VoteInput input)
    {
        Assert(input.ProposalHash != null, "Invalid proposal hash.");
        Assert(input.Option != VoteOption.Abstain, "Abstain vote not allowed.");
        Assert(_proposals.ContainsKey(input.ProposalHash), "Proposal not found.");
        
        // Prevent duplicate voting from the same address (for simplicity)
        Assert(!_voters.ContainsKey(Context.Sender), "Already voted.");
        
        // Record the vote in your state storage (not shown for brevity)
        // ...
        
        _voters.Add(Context.Sender, 1); // Mark voter as having voted
        return new Empty();
    }

    // Additional functions for retrieving proposal details, results, etc.
    // ...
}
