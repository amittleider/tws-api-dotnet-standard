#pragma once
#include "IExternalizable.h"
#include "shared_ptr.h"

class OrderCondition : public IExternalizable {
public:
	enum OrderConditionType {
		Execution,
		Margin,
		PercentChange,
		Price,
		Time,
		Volume
	};

private:
	OrderConditionType m_type;
	bool m_isConjunctionConnection;

public:
	virtual const char* readExternal(const char* ptr, const char* endPtr);
	virtual void writeExternal(std::ostream &out) const;

	std::string toString();
	bool conjunctionConnection() const;
	void conjunctionConnection(bool isConjunctionConnection);	
	OrderConditionType type();
	
	static ibapi::shared_ptr<OrderCondition> create(OrderConditionType type);
};