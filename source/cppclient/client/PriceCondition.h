#pragma once
#include "ContractCondition.h"

class PriceCondition : public ContractCondition {
	friend OrderCondition;

	double m_price;
	int m_triggerMethod;

	virtual std::string valueToString() const;
	virtual void valueFromString(const std::string &v);

protected:
	PriceCondition() { };

public:
	static const OrderConditionType conditionType = OrderConditionType::Price;

	double price();
	void price(double price);

	virtual std::string toString();
	virtual const char* readExternal(const char* ptr, const char* endPtr);
	virtual void writeExternal(std::ostream & out) const;

	int triggerMethod();
	std::string strTriggerMethod();
	void triggerMethod(int triggerMethod);
};